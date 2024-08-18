using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class RegisterDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DemoContext>((serviceProvider, opt) =>
            {
                //... you guys shouls use appSettings.json or the best one is Environment Variable ⚠️
                string? connectionString = config.GetConnectionString("DefaultConnection");
                opt.UseSqlite(connectionString, opt =>
                {
                    opt.CommandTimeout(30);
                });
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork>((sp) => sp.GetRequiredService<DemoContext>());
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentSubjectRespository, StudentSubjectRepository>();
            return services;
        }
    }
}
