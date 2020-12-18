using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using proyecto.Areas.Identity.Data;
using proyecto.Data;

[assembly: HostingStartup(typeof(proyecto.Areas.Identity.IdentityHostingStartup))]
namespace proyecto.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<proyectoContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("proyectoContextConnection")));

                services.AddDefaultIdentity<proyectoUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                    .AddEntityFrameworkStores<proyectoContext>();
            });
        }
    }
}