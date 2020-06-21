using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.Project;
using Ekbatan.Services.Repositories;
using Ekbatan.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DNTPersianUtils.Core;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Ekbatan.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            CultureInfo.DefaultThreadCurrentCulture
                = CultureInfo.DefaultThreadCurrentUICulture = PersianDateExtensionMethods.GetPersianCulture();

            services.Configure<CookiePolicyOptions>(options =>
            {

                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;


            });

           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<EkbatanDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EkbatanDbContext")));
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IMelkRepository, MelkRepository>();
            services.AddTransient<IMelkPositionRepository, MelkPositionRepository>();
            services.AddTransient<IMelkTypeRepository, MelkTypeRepository>();
            services.AddTransient<IMContractRepository, MContractRepository>();
            services.AddTransient<ICustomerRepository, CustomerREpository>();
            services.AddTransient<ISubContrctRepository, SubContractRepository>();
            services.AddTransient<IFrontAgeRepository, FrontAgeRepository>();
            services.AddTransient<IKarbariRepository, KarbariRepository>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
             );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
