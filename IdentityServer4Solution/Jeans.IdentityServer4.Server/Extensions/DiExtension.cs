using LJ.Ids4.Data;
using LJ.Ids4.Service.Clients;
using LJ.Ids4.Service.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace Jeans.IdentityServer4.Server.Extensions
{
    public static class DiExtension
    {
        public static IServiceCollection AddDefaultDi(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, Ids4DbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IResourceService, ResourceService>();

            return services;
        }
    }
}