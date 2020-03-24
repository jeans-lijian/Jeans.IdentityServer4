using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Jeans.IdentityServer4.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("https://*:5001");
    }
}