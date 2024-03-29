﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Data;
using CarRental.Data.Interfaces;
using CarRental.Data.Repositories;
using CarRental.Services.Interfaces;
using CarRental.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IBookServices, BookServices>();
            services.AddTransient<IHomePageServices,HomePageServices>();
            services.AddTransient<ICarRepository,CarRepository>();
            services.AddTransient<IHomePageServices, HomePageServices>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IAdminServices, AdminServices>();
            services.AddTransient<ILocationPointRepository, LocationPointRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            var connection = @"Server=.\SQLEXPRESS;Database=Rent.Database;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<RentACarContext>
                (options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("searchL2", "/kiralik-{carBrand}-{carModel}", new {controller = "Search", action = "Index"});
                routes.MapRoute("searchL1", "/kiralik-{carBrand}", new {controller = "Search", action = "Index"});
                routes.MapRoute("search", "/kiralik-arac", new { controller = "Search", action = "Index" });
                routes.MapRoute("search", "/rezervasyon-bilgi-{id}", new { controller = "Services", action = "Rez-Bilgi" });
                routes.MapRoute("search", "/rezervasyon-sorgu", new { controller = "Services", action = "Index" });
            });
        }
    }
}
