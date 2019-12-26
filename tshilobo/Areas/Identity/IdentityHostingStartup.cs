using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tshilobo.Data;

[assembly: HostingStartup(typeof(tshilobo.Areas.Identity.IdentityHostingStartup))]
namespace tshilobo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<tshiloboDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("tshiloboContextConnection")));

                services.AddDefaultIdentity<tshiloboUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;                    
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<tshiloboDbContext>()
                .AddDefaultTokenProviders();
            });
        }
    }
}