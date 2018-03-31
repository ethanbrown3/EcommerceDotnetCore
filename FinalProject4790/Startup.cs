using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using FinalProject4790.Models.DomainServices;

namespace FinalProject4790
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISellerRepository, MockSellerRepository>();
            services.AddTransient<IProductRepository, MockProductRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // order is important
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:"default",
                    template: "{controller=Home}/{action=Index}/{Id?}"
                );
                routes.MapRoute(
                    "ProductList",                                              // Route name
                    "{controller}/{action}/{Id}/{artistName}",                           // URL with parameters
                    new { controller = "Home", action = "ProductList", Id = "", artistName = "" }  // Parameter defaults
                );
            });
        }
    }
}