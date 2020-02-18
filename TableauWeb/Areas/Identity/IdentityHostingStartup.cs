using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TableauWeb.Areas.Identity.IdentityHostingStartup))]
namespace TableauWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}