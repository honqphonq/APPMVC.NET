using APPMVC.NET.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPMVC.NET
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddSingleton<ProductService>();
            //services.AddSingleton<ProductService, ProductService>();
            services.AddSingleton(typeof(ProductService));
            services.AddSingleton<PlanetService>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            //Khi xay ra loi 404 thi se tao ra mot response phan hoi
            app.UseStatusCodePages();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/sayhi", async (context) =>
                {
                    await context.Response.WriteAsync($"Hello ASP.NET MVC {DateTime.Now}");
                });

                endpoints.MapRazorPages();
                //endpoints.MapControllers();
                //endpoints.MapControllerRoute();
                //endpoints.MapDefaultControllerRoute();
                //endpoints.MapAreaControllerRoute();

                endpoints.MapControllerRoute(
                    name: "first",
                    pattern: "{url}/{id?}",
                    defaults: new
                    {
                        controller = "First",
                        action = "ViewProduct",
                    }
                    //constraints: new
                    //{
                    //    url = "xemsanpham"
                    //}
                    );

                endpoints.MapAreaControllerRoute(
                    name:"product",
                    pattern: "{controller}/{action=Index}/{id?}",
                    areaName:"ProductManage"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //Them endpoint cho RazorPage
                endpoints.MapRazorPages();
            });
        }
    }
}
