using AutoMapper;
using Jeans.IdentityServer4.Server.Configuration;
using Jeans.IdentityServer4.Server.Core.Extensions;
using Jeans.IdentityServer4.Server.Core.IdsStore;
using LJ.Ids4.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddDbContext<Ids4DbContext>(options => options.UseMySql(Configuration.GetConnectionString("Ids4Conn")));
            services.AddDbContext<AppDbContext>(options => options.UseMySql(Configuration.GetConnectionString("AppConn")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    //.AddTestUsers(MemoryConfig.GetTestUsers())
                    .AddResourceStore<CustomResourceStore>()
                    .AddClientStore<CustomClientStore>()
                    .AddResourceOwnerValidator<CustomResourceOwnerValidator>()
                    .AddProfileService<CustomProfileService>();

            services.AddDefaultDi();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
    }
}