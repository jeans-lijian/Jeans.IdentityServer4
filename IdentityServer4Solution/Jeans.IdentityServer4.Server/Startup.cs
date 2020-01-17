using AutoMapper;
using Jeans.IdentityServer4.Server.Configuration;
using Jeans.IdentityServer4.Server.Data;
using Jeans.IdentityServer4.Server.Extensions;
using Jeans.IdentityServer4.Server.StoreImp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Jeans.IdentityServer4.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityServerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("identityserver")));
            services.AddDbContext<ObjectDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("identity")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddIdentityServer()
                    .AddClientStore<JeansClientStore>()
                    .AddResourceStore<JeansResourceStore>()
                    .AddResourceOwnerValidator<JeansResourceOwnerValidator>()
                    .AddProfileService<JeansProfileService>();

            services.AddDefaultDi();

            services.AddAutoMapper(typeof(Startup));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseIdentityServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<IdentityServerDbContext>();
                context.Database.Migrate();
                var objectContext = serviceScope.ServiceProvider.GetRequiredService<ObjectDbContext>();
                context.Database.Migrate();

                if (!context.Clients.Any())
                {
                    foreach (var item in Config.GetClients())
                    {
                        context.Clients.Add(item);
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var item in Config.GetApiResources())
                    {
                        context.ApiResources.Add(item);
                    }
                    context.SaveChanges();
                }

                if (!objectContext.UserEntities.Any())
                {
                    foreach (var item in Config.GetUsers())
                    {
                        objectContext.UserEntities.Add(item);
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var item in Config.GetIdentityResources())
                    {
                        context.IdentityResources.Add(item);
                    }
                    context.SaveChanges();
                }
            }
        }

    }
}
