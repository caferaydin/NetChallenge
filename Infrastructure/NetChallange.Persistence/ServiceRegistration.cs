using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Application.Abstractions.Repository.Write;
using NetChallenge.Application.Abstractions.Services;
using NetChallenge.Persistence.Configurations;
using NetChallenge.Persistence.Context;
using NetChallenge.Persistence.Repositories.Read;
using NetChallenge.Persistence.Repositories.Write;
using NetChallenge.Persistence.Services;

namespace NetChallenge.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddServiceRegistiration(this IServiceCollection services)
        {
            services.AddDbContext<MsSqlDbContext>(options => options.UseSqlServer(MssqlDbConfiguration.ConnectionString));

            services
                // Read Repository
                .AddScoped<ICarrierReadRepository, CarrierReadRepository>()
                .AddScoped<ICarrierConfigurationReadRepository, CarrierConfigurationReadRepository>()
                .AddScoped<IOrderReadRepository, OrderReadRepository>()
                // Write Repository
                .AddScoped<ICarrierWriteRepository, CarrierWriteRepository>()
                .AddScoped<ICarrierConfigurationWriteRepository, CarrierConfigurationWriteRepository>()
                .AddScoped<IOrderWriteRepository, OrderWriteRepository>()
                //Service
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<ICarrierService, CarrierService>()
                .AddScoped<ICarrierConfigurationService, CarrierConfigurationService>()

                ;


        }
    }
}
