using Application.Interfaces;
using Application.Services;
using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class ServiceCollections
    {
        private static string CONNECTION_STRING = "DEFAULT";

        public static IServiceCollection AddContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository(configuration)
                    .AddServices();

            return services;
        }

        private static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = GetConnectionString(configuration);

            services.AddDbContext<DataContext>(options =>
                options.UseSqlite(connection)
            );

            services.AddScoped<PunctuationRepository, PunctuationRepositoryImp>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<PunctuationService, PunctuationServiceImp>();

            return services;
        }

        private static string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString(CONNECTION_STRING);
        }
    }
}
