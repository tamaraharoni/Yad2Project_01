using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Yad2Project.Data;
using Microsoft.EntityFrameworkCore;
using Yad2Project.Repository;
using Yad2Project.Models;

namespace Yad2Project
{
    public class Startup
    {
        private IConfiguration _congiguration;

        public Startup(IConfiguration configuration)
        {
            _congiguration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddDefaultIdentity<User>(options =>
            {
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<Yad2Data>();

            services.AddDbContext<Yad2Data>(options => options.UseSqlite("Data Source=Yad2.db"));
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Yad2Data DataContect, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // DataContect.Database.EnsureDeleted();
            DataContect.Database.EnsureCreated();
            // app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Yad2Project",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Products", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });

        }
    }
}
