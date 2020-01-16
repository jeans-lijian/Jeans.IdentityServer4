using IdentityServer4.Models;
using Jeans.IdentityServer4.Server.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiResource = Jeans.IdentityServer4.Server.Core.Entity.ApiResource;
using Client = Jeans.IdentityServer4.Server.Core.Entity.Client;
using IdentityResource = Jeans.IdentityServer4.Server.Core.Entity.IdentityResource;

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

        public static List<UserEntity> GetUsers()
        {
            var userList = new List<UserEntity>
            {
                new UserEntity
                {
                   UserName="Jeans_Admin",
                   Password="123456",
                   Email="lijiansoftware@163.com"
                },
                new UserEntity
                {
                   UserName="Admin",
                   Password="123456",
                   Email="185416672@qq.com"
                }
            };

            return userList;
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResource
                {
                    Name="openId",
                    DisplayName="OpenId",
                    Required=true
                },
                new IdentityResource
                {
                    Name="email",
                    DisplayName="Email",
                    Required=true
                },
                new IdentityResource
                {
                    Name="profile",
                    DisplayName="Profile",
                    Required=true
                },
                new IdentityResource
                {
                    Name="phone",
                    DisplayName="Phone",
                    Required=true
                }
            };
        }

    }
}
