using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_Database.Models;
using Pomelo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using MVC_Database.Models.Services;
using MVC_Database.Models.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Identity.Core;

namespace MVC_Database
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


            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddMvc();
            services.AddRazorPages();
            //services.AddControllersWithViews();
            // services.AddCors();
            //services.AddDbContext<AppDbContext>(options =>
            //     options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"), 
            //                ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection"))));
            // Testing MySql injecting 
            services.AddScoped<IServicePeople, PeopleRepos>();
            services.AddScoped<ICityService, CityRepos>();
            services.AddScoped<ICountryService, CountryRepos>();
            services.AddScoped<ILanguageService, LanguageRepos>();
            services.AddScoped<IReactService,ReactRepos>();

            services.AddHttpContextAccessor();

            services.AddDbContext<AppDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddDefaultUI()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<AppDbContext>();

            services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                }
            );


            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(20);//You can set Time   
            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{Controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapRazorPages();

            });
            //app.UseCors(builder =>
            //{
            //    builder
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader();
            //});
        }
    }
}
