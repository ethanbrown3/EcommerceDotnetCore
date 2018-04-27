using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FinalProject4790.Models;
using FinalProject4790.Models.DomainServices;
using Microsoft.AspNetCore.Identity;
using Stripe;
using FinalProject4790.Models.Domain;
using FinalProject4790.Auth;

namespace FinalProject4790
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AppDbContext>();
            // Register Repositories with DI
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ICreditTransactionRepository, CreditTransactionRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            services.AddMvc()
                .AddSessionStateTempDataProvider();
            
            services.AddSession();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);
            // order is important
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            
            DbInitializer.SeedAdmin(roleManager, userManager);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:"default",
                    template: "{controller=Home}/{action=Index}"
                );

                routes.MapRoute(
                    "ProductList",                                              // Route name
                    "{controller}/{action}/{Id}/{artistName}",                           // URL with parameters
                    new { controller = "Product", action = "ProductList", Id = "", artistName = "" }  // Parameter defaults
                );
                
                routes.MapRoute(
                    "ShoppingCart",                                              // Route name
                    "{controller}/{action}",                           // URL with parameters
                    new { controller = "ShoppingCart", action = "Index" }  // Parameter defaults
                );
            });
        }
    }
}