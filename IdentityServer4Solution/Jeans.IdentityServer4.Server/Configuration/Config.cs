using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Configuration
{
    public class Config
    {
        public static List<Client> GetClients()
        {
            var clientList = new List<Client>();
            clientList.Add(new Client
            {
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientId = "Jeans",
                ClientSecrets = new List<Secret>
                {
                    new Secret("123456".Sha256())
                }
            });

            return clientList;
        }

        public static List<ApiResource> GetApiResources()
        {
            var apiList = new List<ApiResource>();
            apiList.Add(new ApiResource
            {
                Name="user",
                Description="获取用户信息"
            });

            return apiList;
        }

    }
}
