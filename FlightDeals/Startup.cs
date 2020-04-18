using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FlightDeals.Services.Interfaces;
using FlightDeals.Features;
using AutoMapper;
using FlightDeals.Services;
using System.IO;
using FlightDeals.Data;
using Microsoft.EntityFrameworkCore;
using FlightDeals.Data.AirportProvider;

namespace FlightDeals
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

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc(o =>
            {
                o.Conventions.Add(new FeatureConvention());
                //   o.EnableEndpointRouting = false;
            })
            .AddRazorOptions(o =>
            {
                //{0} - action,   {1} - controller ,    {2} - area, {3} - feature
                o.ViewLocationFormats.Clear();
                o.ViewLocationFormats.Add("/Features/{3}/{1}/{0}.cshtml");
                o.ViewLocationFormats.Add("/Features/{3}/{0}.cshtml");
                o.ViewLocationFormats.Add("/Features/Shared/{0}.cshtml");
                o.ViewLocationExpanders.Add(new FeatureViewLocationExpander());                

            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddHttpClient<IFlightOffersClient, FlightOffersClient>(
                client =>
                {
                    client.BaseAddress = new Uri("https://test.api.amadeus.com/");
                });
            services.AddDbContext<FlightDealsContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:FlightDealsDB"]));
            services.AddSingleton<IAirportProvider, AirportProvider>();

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
                app.UseExceptionHandler("Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
         
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(routes =>
            {
               // routes.MapDefaultControllerRoute();
                routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
