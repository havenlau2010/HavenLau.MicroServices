using Microsoft.Extensions.DependencyInjection;
using Namotion.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HavenLau.Consul.Server
{
    public class ConsulGenerator
    {
        //protected Assembly[] LoadAssemblies(IEnumerable<string> assemblyPaths, AssemblyLoader assemblyLoader)
        //{
        //    var currentDirectory = DynamicApis.DirectoryGetCurrentDirectory();
        //    var assemblies = PathUtilities.ExpandFileWildcards(assemblyPaths)
        //        .Select(path => assemblyLoader.Context.LoadFromAssemblyPath(PathUtilities.MakeAbsolutePath(path, currentDirectory)))
        //        .ToArray();
        //    return assemblies;
        //}

        #region 私有方法
        private IEnumerable<string> GetSupportedHttpMethods(MethodInfo method)
        {
            // See http://www.asp.net/web-api/overview/web-api-routing-and-actions/routing-in-aspnet-web-api

            var actionName = GetActionName(method);

            var httpMethods = GetSupportedHttpMethodsFromAttributes(method).ToArray();
            foreach (var httpMethod in httpMethods)
            {
                yield return httpMethod;
            }

            if (httpMethods.Length == 0)
            {
                if (actionName.StartsWith("Get", StringComparison.OrdinalIgnoreCase))
                {
                    yield return OpenApiOperationMethod.Get;
                }
                else if (actionName.StartsWith("Post", StringComparison.OrdinalIgnoreCase))
                {
                    yield return OpenApiOperationMethod.Post;
                }
                else if (actionName.StartsWith("Put", StringComparison.OrdinalIgnoreCase))
                {
                    yield return OpenApiOperationMethod.Put;
                }
                else if (actionName.StartsWith("Delete", StringComparison.OrdinalIgnoreCase))
                {
                    yield return OpenApiOperationMethod.Delete;
                }
                else if (actionName.StartsWith("Patch", StringComparison.OrdinalIgnoreCase))
                {
                    yield return OpenApiOperationMethod.Patch;
                }
                else if (actionName.StartsWith("Options", StringComparison.OrdinalIgnoreCase))
                {
                    yield return OpenApiOperationMethod.Options;
                }
                else if (actionName.StartsWith("Head", StringComparison.OrdinalIgnoreCase))
                {
                    yield return OpenApiOperationMethod.Head;
                }
                else
                {
                    yield return OpenApiOperationMethod.Post;
                }
            }
        }
        private IEnumerable<string> GetSupportedHttpMethodsFromAttributes(MethodInfo method)
        {
            if (method.GetCustomAttributes().Any(a => a.GetType().Name == "HttpGetAttribute"))
            {
                yield return OpenApiOperationMethod.Get;
            }

            if (method.GetCustomAttributes().Any(a => a.GetType().Name == "HttpPostAttribute"))
            {
                yield return OpenApiOperationMethod.Post;
            }

            if (method.GetCustomAttributes().Any(a => a.GetType().Name == "HttpPutAttribute"))
            {
                yield return OpenApiOperationMethod.Put;
            }

            if (method.GetCustomAttributes().Any(a => a.GetType().Name == "HttpDeleteAttribute"))
            {
                yield return OpenApiOperationMethod.Delete;
            }

            if (method.GetCustomAttributes().Any(a => a.GetType().Name == "HttpOptionsAttribute"))
            {
                yield return OpenApiOperationMethod.Options;
            }

            if (method.GetCustomAttributes().Any(a => a.GetType().Name == "HttpPatchAttribute"))
            {
                yield return OpenApiOperationMethod.Patch;
            }

            if (method.GetCustomAttributes().Any(a => a.GetType().Name == "HttpHeadAttribute"))
            {
                yield return OpenApiOperationMethod.Head;
            }

            dynamic acceptVerbsAttribute = method.GetCustomAttributes()
                .SingleOrDefault(a => a.GetType().Name == "AcceptVerbsAttribute");

            if (acceptVerbsAttribute != null)
            {
                var httpMethods = acceptVerbsAttribute.HttpMethods is ICollection<Attribute>
                    ? ((ICollection<Attribute>)acceptVerbsAttribute.HttpMethods).OfType<object>().Select(v => v.ToString().ToLowerInvariant())
                    : ((IEnumerable<string>)acceptVerbsAttribute.HttpMethods).Select(v => v.ToLowerInvariant());

                foreach (var verb in httpMethods)
                {
                    if (verb == "get")
                    {
                        yield return OpenApiOperationMethod.Get;
                    }
                    else if (verb == "post")
                    {
                        yield return OpenApiOperationMethod.Post;
                    }
                    else if (verb == "put")
                    {
                        yield return OpenApiOperationMethod.Put;
                    }
                    else if (verb == "delete")
                    {
                        yield return OpenApiOperationMethod.Delete;
                    }
                    else if (verb == "options")
                    {
                        yield return OpenApiOperationMethod.Options;
                    }
                    else if (verb == "head")
                    {
                        yield return OpenApiOperationMethod.Head;
                    }
                    else if (verb == "patch")
                    {
                        yield return OpenApiOperationMethod.Patch;
                    }
                }
            }
        }
        /// <exception cref="InvalidOperationException">The operation has more than one body parameter.</exception>
        private bool GenerateForController(ConsulOption option,Type controllerType)
        {
            var hasIgnoreAttribute = controllerType.GetTypeInfo()
                .GetCustomAttributes()
                .GetAssignableToTypeName("ConsulIgnoreAttribute", TypeNameStyle.Name)
                .Any();

            if (hasIgnoreAttribute)
            {
                return false;
            }

            var operations = new List<Tuple<OpenApiOperationDescription, MethodInfo>>();

            var currentControllerType = controllerType;
            ConsulOption.CheckItem item ;
            while (currentControllerType != null)
            {
                foreach (var method in GetActionMethods(currentControllerType))
                {
                    var httpPaths = GetHttpPaths(controllerType, method).ToList();
                    var httpMethods = GetSupportedHttpMethods(method).ToList();

                    foreach (var httpPath in httpPaths)
                    {
                        foreach (var httpMethod in httpMethods)
                        {
                            var isPathAlreadyDefinedInInheritanceHierarchy =
                                operations.Any(o => o.Item1.Path == httpPath &&
                                                    o.Item1.Method == httpMethod &&
                                                    o.Item2.DeclaringType != currentControllerType &&
                                                    o.Item2.DeclaringType.IsAssignableToTypeName(currentControllerType.FullName, TypeNameStyle.FullName));

                            if (isPathAlreadyDefinedInInheritanceHierarchy == false)
                            {
                                var operationDescription = new OpenApiOperationDescription
                                {
                                    Path = httpPath,
                                    Method = httpMethod,
                                    Operation = new
                                    {
                                        IsDeprecated = method.GetCustomAttribute<ObsoleteAttribute>() != null
                                    }
                                };

                                operations.Add(new Tuple<OpenApiOperationDescription, MethodInfo>(operationDescription, method));


                                #region 添加Consul逻辑
                                item = new ConsulOption.CheckItem() { Url = operationDescription.Path };
                                option.Checks.Add(item);
                                #endregion
                            }
                        }
                    }
                }

                currentControllerType = currentControllerType.GetTypeInfo().BaseType;
            }

            return AddOperationDescriptionsToDocument(currentControllerType, operations);
        }

        private bool AddOperationDescriptionsToDocument(Type controllerType, List<Tuple<OpenApiOperationDescription, MethodInfo>> operations)
        {
            var addedOperations = 0;
            var allOperation = operations.Select(t => t.Item1).ToList();
            foreach (var tuple in operations)
            {
                var operation = tuple.Item1;
                var method = tuple.Item2;
            }

            return addedOperations > 0;
        }

        private static IEnumerable<MethodInfo> GetActionMethods(Type controllerType)
        {
            var methods = controllerType.GetRuntimeMethods().Where(m => m.IsPublic);
            return methods.Where(m =>
                m.IsSpecialName == false && // avoid property methods
                m.DeclaringType == controllerType && // no inherited methods (handled in GenerateForControllerAsync)
                m.DeclaringType != typeof(object) &&
                m.IsStatic == false &&
                m.GetCustomAttributes().Select(a => a.GetType()).All(a =>
                    !a.IsAssignableToTypeName("SwaggerIgnoreAttribute", TypeNameStyle.Name) &&
                    !a.IsAssignableToTypeName("NonActionAttribute", TypeNameStyle.Name)) &&
                m.DeclaringType.FullName.StartsWith("Microsoft.AspNet") == false && // .NET Core (Web API & MVC)
                m.DeclaringType.FullName != "System.Web.Http.ApiController" &&
                m.DeclaringType.FullName != "System.Web.Mvc.Controller")
                .Where(m =>
                {
                    return m.GetCustomAttributes()
                        .SingleOrDefault(a => a.GetType().Name == "ApiExplorerSettingsAttribute")?
                        .TryGetPropertyValue("IgnoreApi", false) != true;
                });
        }

        private string GetOperationId(ConsulOption document, string controllerName, MethodInfo method)
        {
            string operationId;

            dynamic swaggerOperationAttribute = method
                .GetCustomAttributes()
                .FirstAssignableToTypeNameOrDefault("SwaggerOperationAttribute", TypeNameStyle.Name);

            if (swaggerOperationAttribute != null && !string.IsNullOrEmpty(swaggerOperationAttribute.OperationId))
            {
                operationId = swaggerOperationAttribute.OperationId;
            }
            else
            {
                if (controllerName.EndsWith("Controller"))
                {
                    controllerName = controllerName.Substring(0, controllerName.Length - 10);
                }

                operationId = controllerName + "_" + GetActionName(method);
            }

            var number = 1;
            //while (document.Operations.Any(o => o.Operation.OperationId == operationId + (number > 1 ? "_" + number : string.Empty)))
            //{
            //    number++;
            //}

            return operationId + (number > 1 ? number.ToString() : string.Empty);
        }

        private IEnumerable<string> GetHttpPaths(Type controllerType, MethodInfo method)
        {
            var httpPaths = new List<string>();
            var controllerName = controllerType.Name.Replace("Controller", string.Empty);

            var routeAttributes = GetRouteAttributes(method.GetCustomAttributes()).ToList();

            // .NET Core: RouteAttribute on class level
            var routeAttributeOnClass = GetRouteAttribute(controllerType);
            var routePrefixAttribute = GetRoutePrefixAttribute(controllerType);

            if (routeAttributes.Any())
            {
                foreach (var attribute in routeAttributes)
                {
                    if (attribute.Template.StartsWith("~/")) // ignore route prefixes
                    {
                        httpPaths.Add(attribute.Template.Substring(1));
                    }
                    else if (routePrefixAttribute != null)
                    {
                        httpPaths.Add(routePrefixAttribute.Prefix + "/" + attribute.Template);
                    }
                    else if (routeAttributeOnClass != null)
                    {
                        if (attribute.Template.StartsWith("/"))
                        {
                            httpPaths.Add(attribute.Template);
                        }
                        else
                        {
                            httpPaths.Add(routeAttributeOnClass.Template + "/" + attribute.Template);
                        }
                    }
                    else
                    {
                        httpPaths.Add(attribute.Template);
                    }
                }
            }
            else if (routePrefixAttribute != null && routeAttributeOnClass != null)
            {
                httpPaths.Add(routePrefixAttribute.Prefix + "/" + routeAttributeOnClass.Template);
            }
            else if (routePrefixAttribute != null)
            {
                httpPaths.Add(routePrefixAttribute.Prefix);
            }
            else if (routeAttributeOnClass != null)
            {
                httpPaths.Add(routeAttributeOnClass.Template);
            }
            else
            {
                string defaultUrlTemplate = "api/{controller}/{id?}";
                httpPaths.Add(defaultUrlTemplate ?? string.Empty);
            }

            var actionName = GetActionName(method);
            return httpPaths
                .SelectMany(p => ExpandOptionalHttpPathParameters(p, method))
                .Select(p =>
                    "/" + p
                        .Replace("[", "{")
                        .Replace("]", "}")
                        .Replace("{controller}", controllerName)
                        .Replace("{action}", actionName)
                        .Replace("{*", "{") // wildcard path parameters are not supported in Swagger
                        .Trim('/'))
                .Distinct()
                .ToList();
        }

        private IEnumerable<string> ExpandOptionalHttpPathParameters(string path, MethodInfo method)
        {
            var segments = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < segments.Length; i++)
            {
                var segment = segments[i];
                if (segment.EndsWith("?}"))
                {
                    // Only expand if optional parameter is available in action method
                    if (method.GetParameters().Any(p => segment.StartsWith("{" + p.Name + ":") || segment.StartsWith("{" + p.Name + "?")))
                    {
                        foreach (var p in ExpandOptionalHttpPathParameters(string.Join("/", segments.Take(i).Concat(new[] { segment.Replace("?", "") }).Concat(segments.Skip(i + 1))), method))
                        {
                            yield return p;
                        }
                    }
                    else
                    {
                        foreach (var p in ExpandOptionalHttpPathParameters(string.Join("/", segments.Take(i).Concat(segments.Skip(i + 1))), method))
                        {
                            yield return p;
                        }
                    }

                    yield break;
                }
            }

            yield return path;
        }

        private RouteAttributeFacade GetRouteAttribute(Type type)
        {
            do
            {
                var attributes = type.GetTypeInfo().GetCustomAttributes(false).Cast<Attribute>();

                var attribute = GetRouteAttributes(attributes).SingleOrDefault();
                if (attribute != null)
                {
                    return attribute;
                }

                type = type.GetTypeInfo().BaseType;
            } while (type != null);

            return null;
        }

        private RoutePrefixAttributeFacade GetRoutePrefixAttribute(Type type)
        {
            do
            {
                var attributes = type.GetTypeInfo().GetCustomAttributes(false).Cast<Attribute>();

                var attribute = GetRoutePrefixAttributes(attributes).SingleOrDefault();
                if (attribute != null)
                {
                    return attribute;
                }

                type = type.GetTypeInfo().BaseType;
            } while (type != null);

            return null;
        }

        private IEnumerable<RouteAttributeFacade> GetRouteAttributes(IEnumerable<Attribute> attributes)
        {
            return attributes.Select(RouteAttributeFacade.TryMake).Where(a => a?.Template != null);
        }

        private IEnumerable<RoutePrefixAttributeFacade> GetRoutePrefixAttributes(IEnumerable<Attribute> attributes)
        {
            return attributes.Select(RoutePrefixAttributeFacade.TryMake).Where(a => a != null);
        }

        private string GetActionName(MethodInfo method)
        {
            dynamic actionNameAttribute = method.GetCustomAttributes()
                .SingleOrDefault(a => a.GetType().Name == "ActionNameAttribute");

            if (actionNameAttribute != null)
            {
                return actionNameAttribute.Name;
            }

            var methodName = method.Name;
            if (methodName.EndsWith("Async"))
            {
                methodName = methodName.Substring(0, methodName.Length - 5);
            }

            return methodName;
        }
        #endregion

        #region 公開方法
        /// <summary>Gets all controller class types of the given assembly.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The controller classes.</returns>
        public static IEnumerable<Type> GetControllerClasses(Assembly assembly)
        {
            // TODO: Move to IControllerClassLoader interface
            return assembly.ExportedTypes
                .Where(t => t.GetTypeInfo().IsAbstract == false)
                .Where(t => t.Name.EndsWith("Controller") ||
                            t.InheritsFromTypeName("ApiController", TypeNameStyle.Name) ||
                            t.InheritsFromTypeName("ControllerBase", TypeNameStyle.Name)) // in ASP.NET Core, a Web API controller inherits from Controller
                .Where(t => t.GetTypeInfo().ImplementedInterfaces.All(i => i.FullName != "System.Web.Mvc.IController")) // no MVC controllers (legacy ASP.NET)
                .Where(t =>
                {
                    return t.GetTypeInfo().GetCustomAttributes()
                        .SingleOrDefault(a => a.GetType().Name == "ApiExplorerSettingsAttribute")?
                        .TryGetPropertyValue("IgnoreApi", false) != true;

                });
        }

        /// <summary>Generates a Swagger specification for the given controller types.</summary>
        /// <param name="controllerTypes">The types of the controller.</param>
        /// <returns>The <see cref="OpenApiDocument" />.</returns>
        /// <exception cref="InvalidOperationException">The operation has more than one body parameter.</exception>
        public ConsulOption GenerateForControllers(IEnumerable<Type> controllerTypes)
        {
            ConsulOption option = new ConsulOption();
            var usedControllerTypes = new List<Type>();
            foreach (var controllerType in controllerTypes)
            {
                var isIncluded = GenerateForController(option,controllerType);
                if (isIncluded)
                {
                    usedControllerTypes.Add(controllerType);
                }
            }
            return option;
        }
        #endregion
    }
}
