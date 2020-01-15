using Jeans.IdentityServer4.Server.Data;
using Jeans.IdentityServer4.Server.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Extensions
{
    public static class DiExtension
    {
        public static IServiceCollection AddDefaultDi(this IServiceCollection services)
        {
            services.AddSingleton<IDbContext, IdentityServerDbContext>();
            services.AddSingleton(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IResourceService, ResourceService>();
            services.AddTransient<IIdentityResourceService, IdentityResourceService>();
            services.AddTransient<IUserEntityService, UserEntityService>();

            return services;
        }
    }
}
