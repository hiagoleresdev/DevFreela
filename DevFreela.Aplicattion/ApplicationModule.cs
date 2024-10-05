using DevFreela.Application.Services;
using DevFreela.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddServices();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();  
            services.AddScoped<IUserService, UserService>();    
            services.AddScoped<ISkillService, SkillService>();    

            return services;
        }
    }
}
