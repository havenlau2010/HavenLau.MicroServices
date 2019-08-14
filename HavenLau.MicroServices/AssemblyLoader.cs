using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime.Loader;
namespace HavenLau.Consul.Server
{
    public class AssemblyLoader
    {
        public CustomAssemblyLoadContext Context { get; }

        public AssemblyLoader()
        {
            Context = new CustomAssemblyLoadContext();
            AssemblyLoadContext.Default.Resolving += (context, name) => Context.Resolve(name);
        }

        public Type GetType(string typeName)
        {
            try
            {
                var split = typeName.Split(':');
                if (split.Length > 1)
                {
                    var assemblyName = split[0].Trim();
                    typeName = split[1].Trim();
                    var assembly = Context.LoadFromAssemblyName(new AssemblyName(assemblyName));
                    return assembly.GetType(typeName, true);
                }
                return Type.GetType(typeName, true, true);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Could not instantiate the type '" + typeName + "'. Try specifying the type with the assembly, e.g 'assemblyName:typeName'.", e);
            }
        }

        public object CreateInstance(string typeName)
        {
            return Activator.CreateInstance(GetType(typeName));
        }

        protected void RegisterReferencePaths(IEnumerable<string> referencePaths)
        {
            var allReferencePaths = new List<string>();
            foreach (var path in referencePaths.Where(p => !string.IsNullOrWhiteSpace(p)))
            {
                allReferencePaths.Add(path);
                allReferencePaths.AddRange(GetAllDirectories(path));
            }

            // Add path to executable directory
            allReferencePaths.Add(Path.GetDirectoryName(typeof(AssemblyLoader).GetTypeInfo().Assembly.Location));
            allReferencePaths = allReferencePaths.Distinct().ToList();
            allReferencePaths.AddRange(GetAllDirectories(AppDomain.CurrentDomain.BaseDirectory));

            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                Version version = null;

                var separatorIndex = args.Name.IndexOf(",", StringComparison.Ordinal);
                var assemblyName = separatorIndex > 0 ? args.Name.Substring(0, separatorIndex) : args.Name;

                if (separatorIndex > 0)
                {
                    separatorIndex = args.Name.IndexOf("=", separatorIndex, StringComparison.Ordinal);
                    if (separatorIndex > 0)
                    {
                        var endIndex = args.Name.IndexOf(",", separatorIndex, StringComparison.Ordinal);
                        if (endIndex > 0)
                        {
                            var parts = args.Name
                                .Substring(separatorIndex + 1, endIndex - separatorIndex - 1)
                                .Split('.');

                            version = new Version(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                        }
                    }
                }

                var existingAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == assemblyName);
                if (existingAssembly != null)
                {
                    return existingAssembly;
                }

                if (version != null)
                {
                    var assemblyByVersion = TryLoadByVersion(allReferencePaths, assemblyName, version.Major + "." + version.Minor + "." + version.Build + ".");
                    if (assemblyByVersion != null)
                    {
                        return assemblyByVersion;
                    }

                    assemblyByVersion = TryLoadByVersion(allReferencePaths, assemblyName, version.Major + "." + version.Minor + ".");
                    if (assemblyByVersion != null)
                    {
                        return assemblyByVersion;
                    }

                    assemblyByVersion = TryLoadByVersion(allReferencePaths, assemblyName, version.Major + ".");
                    if (assemblyByVersion != null)
                    {
                        return assemblyByVersion;
                    }
                }

                var assembly = TryLoadByName(allReferencePaths, assemblyName);
                if (assembly != null)
                {
                    return assembly;
                }

                return null;
            };
        }

        private Assembly TryLoadByVersion(List<string> allReferencePaths, string assemblyName, string assemblyVersion)
        {
            foreach (var path in allReferencePaths)
            {
                var files = Directory.GetFiles(path, assemblyName + ".dll", SearchOption.TopDirectoryOnly);
                foreach (var file in files)
                {
                    try
                    {
                        var info = FileVersionInfo.GetVersionInfo(file);
                        if (info.FileVersion.StartsWith(assemblyVersion))
                        {
                            return Assembly.LoadFrom(file);
                        }
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine("NSwag: AssemblyLoader exception when loading assembly by file '" + file + "': \n" + exception);
                    }
                }
            }

            return null;
        }

        private Assembly TryLoadByName(List<string> allReferencePaths, string assemblyName)
        {
            foreach (var path in allReferencePaths)
            {
                var files = Directory.GetFiles(path, assemblyName + ".dll", SearchOption.TopDirectoryOnly);
                foreach (var file in files)
                {
                    try
                    {
                        return Assembly.LoadFrom(file);
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine("NSwag: AssemblyLoader exception when loading assembly by file '" + file + "': \n" + exception);
                    }
                }
            }

            return null;
        }

        private string[] GetAllDirectories(string rootDirectory)
        {
            rootDirectory = Environment.ExpandEnvironmentVariables(rootDirectory);

            try
            {
                return Directory.GetDirectories(rootDirectory, "*", SearchOption.AllDirectories);
            }
            catch // https://github.com/RicoSuter/NSwag/issues/2177
            {
                return new string[0];
            }
        }
    }
}
