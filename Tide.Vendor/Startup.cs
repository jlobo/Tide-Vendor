using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tide.Middleware;
using Tide.Vendor.Classes;

namespace Tide.Vendor
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
            services.AddTide(options => options.VendorId = "YourVendorId");
            services.AddScoped<UserService>();

            services.AddSpaStaticFiles(opt => opt.RootPath = "Client/dist");

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserService userService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseTide(userService.HandleTideAuthenticationResult);

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSpaStaticFiles();
            app.UseSpa(spa => spa.Options.SourcePath = "Client");
        }
    }
}
