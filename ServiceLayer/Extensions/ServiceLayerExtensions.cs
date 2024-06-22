using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Extensions.Identity;
using ServiceLayer.FluentValidation.WebApplication.AboutValidation;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services ,  IConfiguration configuration)
        {
            services.LoadServiceIdentityExtensions(configuration);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x=>x.IsClass &&  !x.IsAbstract && x.Name.EndsWith("Service"));
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IHomePageService, HomePageService>();
            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ITestmonalService, TestmonalService>();
            services.AddScoped<ICandidateService, CandidateService>();
           services.AddScoped<IServiceService, ServiceService>();
            foreach (var serviceType in types)
            {
                var iserviceType = serviceType.GetInterfaces().FirstOrDefault(x => x.Name == $"I{serviceType.Name}" );

                if (iserviceType == null)
                {
                    services.AddScoped(iserviceType = serviceType);
                }

            }

            services.AddFluentValidationAutoValidation(opt =>
            {
                opt.DisableDataAnnotationsValidation = true;
            }
            );

            services.AddValidatorsFromAssemblyContaining<AboutAddValidation>();
            return services;

            
        }
    }
}
