using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Context;
using ServiceLayer.Helpers.Identity.EmailHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Extensions.Identity
{
    public static class IdentityExtensions
    {
        public static IServiceCollection LoadServiceIdentityExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 10;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequiredUniqueChars = 2;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
                opt.Lockout.MaxFailedAccessAttempts = 3;

            })
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opt =>
            {
                var newCookie = new CookieBuilder();
                newCookie.Name = "HRM";
                opt.LoginPath =  new PathString("/Authentication/LogIn");
                opt.LogoutPath = new PathString( "/Authentication/LogOut");
                opt.AccessDeniedPath =new PathString( "/Authentication/AccessDenied");
                opt.Cookie = newCookie;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                
            });


            //services.ConfigureApplicationCookie(opt =>
            //    {
            //        var newCookie = new CookieBuilder();
            //        newCookie.Name = new PathString( " HRM ");
            //        opt.LoginPath = new PathString( "/Authentication/LogIN");
            //        opt.LogoutPath = new PathString( "/Authentication/LogOut");
            //        opt.AccessDeniedPath = new PathString( "/Authentication/AccessDenied");
            //        opt.Cookie = newCookie;
            //        opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);

            //});
            services.AddScoped<IEmailSendMethod, EmailSendMethod>();
            services.Configure<GmailInformationVM>(config.GetSection("EmailSettings"));
                
            return services;
        }
    }
}
