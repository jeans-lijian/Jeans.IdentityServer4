using LJ.Ids4.Core.Domain.Accounts;
using LJ.Ids4.Data;
using LJ.Ids4.Service.Clients;
using LJ.Ids4.Service.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Jeans.IdentityServer4.Server.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDefaultDi(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                        .AddEntityFrameworkStores<AppDbContext>()
                        .AddDefaultTokenProviders();

            services.AddScoped<IIds4DbContext, Ids4DbContext>();
            services.AddScoped(typeof(IIds4Repository<>), typeof(Ids4EfRepository<>));

            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped(typeof(IAppRepository<>), typeof(AppEfRepository<>));

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IResourceService, ResourceService>();

            return services;
        }
    }
}