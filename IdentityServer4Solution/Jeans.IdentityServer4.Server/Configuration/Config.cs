using IdentityServer4.Models;
using Jeans.IdentityServer4.Server.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiResource = Jeans.IdentityServer4.Server.Core.Entity.ApiResource;
using Client = Jeans.IdentityServer4.Server.Core.Entity.Client;

namespace Jeans.IdentityServer4.Server.Configuration
{
    public class Config
    {
        public static List<Client> GetClients()
        {
            var clientList = new List<Client>
            {
                new Client
                {
                    ClientId = "Jeans",
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret{Value="123456".Sha256() }
                    },
                    ClientGrantTypes = new List<ClientGrantType>
                    {
                        new ClientGrantType
                        {
                            GrantType=GrantType.ResourceOwnerPassword
                        }
                    }
                }
            };

            return clientList;
        }

        public static List<ApiResource> GetApiResources()
        {
            var apiList = new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "user",
                    Description = "获取用户信息"
                }
            };

            return apiList;
        }

    }
}
