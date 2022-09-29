using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ch04MovieListMiner.Models;

namespace Ch04MovieListMiner
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
            services.AddDbContext<Ch04MovieListMiner.Models.MovieContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MovieContext")));
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapAreaControllerRoute( //admin route
                   name: "admin",
                   areaName: "Admin",
                   pattern: "Admin/{controller=Home}/{action=Dummy3}/{id?}"
                   );
                endpoints.MapControllers(); //mapping for attribute route controllers
                endpoints.MapControllerRoute( //custom routing rule
                    name: "Dummy1",
                    pattern: "{controller}/{action}/{cat}/page{num}"
                    );
                endpoints.MapControllerRoute( //default Route
                    name: "default",
                    pattern: "{controller=Home}/{action=Dummy3}/{id?}/{slug?}");
            });
        }
    }
}
