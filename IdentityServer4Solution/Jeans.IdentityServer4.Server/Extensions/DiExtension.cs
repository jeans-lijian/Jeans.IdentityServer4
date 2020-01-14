using Jeans.IdentityServer4.Server.Data;
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

            return services;
        }
    }
}
