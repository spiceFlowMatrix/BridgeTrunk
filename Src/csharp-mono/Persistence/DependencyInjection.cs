using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bridge.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Bridge.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BridgeDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("BridgeDatabase")));

            services.AddScoped<IBridgeDbContext>(provider => provider.GetService<BridgeDbContext>());

            return services;
        }
    }
}