using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HavenLau.Ids.Config
{
    public static class InMemoryConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[] {
                new ApiResource("blog.core.api","Blog.Core API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[] {
                new Client{
                    ClientId = "blogvuejs",
                    ClientSecrets = new []{ new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new []{ "blog.core.api" }
                }
            };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                    new TestUser
                    {
                        SubjectId = "1",
                        Username = "laozhang",
                        Password = "laozhang"
                    }
            };
        }
    }
}
