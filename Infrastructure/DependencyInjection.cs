using Bridge.Common;
using Bridge.Infrastructure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bridge.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddTransient<IDateTime, MachineDateTime>();
            services.Configure<AuthManagementApiConnectionOptions>(configuration);

            return services;
        }
    }
}