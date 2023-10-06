using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidApp_Part2.Data;
using CovidApp_Part2.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CovidApp_Part2
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserValidator<IdentityUser>, CustomUserValidator>();

            services.AddControllersWithViews();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppIdentityDbContext>()
              .AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //Create default Admin user
            AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, _configuration)
                .Wait();

            //Create other user roles
            AppIdentityDbContext.CreateUserRoles(app.ApplicationServices, _configuration)
                .Wait();
        }
    }
}
