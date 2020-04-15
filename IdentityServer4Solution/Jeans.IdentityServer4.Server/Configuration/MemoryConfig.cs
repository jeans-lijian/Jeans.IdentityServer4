using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Jeans.IdentityServer4.Server.Configuration
{
    public class MemoryConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            var apiList = new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "user_api",
                    Description = "管理用户信息",
                    DisplayName="用户API",
                    Scopes=new List<Scope>
                    {
                        new Scope
                        {
                            Name="user_api.full_sccess"
                        },
                        new Scope
                        {
                            Name="user_api.read_only"
                        }
                    }
                }
            };

            return apiList;
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "service.client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "user_api.read_only" }
                },
                new Client
                {
                    ClientId = "api.client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = { "user_api.full_sccess", "user_api.read_only" }
                }
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="Jeans",
                    Password="123456",
                    IsActive=true,
                    Claims=new List<Claim>{
                        new Claim("role","test")
                    }
                }
            };
        }
    }
}