using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bridge.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace Bridge.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string dbconnection = string.Empty;
            dbconnection = Environment.GetEnvironmentVariable("ASPNET_DB_CONNECTIONSTRING");
            
            services.AddDbContext<BridgeDbContext>(options =>
                options.UseMySql(dbconnection));

            services.AddScoped<IBridgeDbContext>(provider => provider.GetService<BridgeDbContext>());

            return services;
        }
    }
}