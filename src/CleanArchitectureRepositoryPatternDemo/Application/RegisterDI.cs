using Application.Mappings;
using Application.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class RegisterDI
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddMapster();
            MapsterConfig.ConfigureMapster();
            services.AddScoped<StudentService>();
            return services;
        }
    }
}