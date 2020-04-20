using System;
using System.Collections.Generic;
using System.Security.Claims;
using Bridge.Application.Interfaces;
using Bridge.Common;
using Bridge.Infrastructure.Identity;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Infrastructure.Unleash;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Application.Interfaces;
using Infrastructure.Identity;

namespace Bridge.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddTransient<IDateTime, MachineDateTime>();
            services.Configure<AuthManagementApiConnectionOptions>(configuration);

            services.AddScoped<IUserManager, UserManagerService>();
            services.AddScoped<IFeatureFlagService, FeatureFlagService>();
            services.AddScoped<IIdentityUserManager, IdentityUserManagerService>();

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseMySql(Environment.GetEnvironmentVariable("ASPNET_DB_CONNECTIONSTRING")));

             services.AddDefaultIdentity<ApplicationUser>()
                     .AddRoles<ApplicationRole>()
                     .AddEntityFrameworkStores<IdentityDbContext>();

            if (environment.IsEnvironment("Test"))
            {
                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, IdentityDbContext>(options =>
                    {
                        options.Clients.Add(new Client
                        {
                            ClientId = "Bridge.IntegrationTests",
                            AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                            ClientSecrets = { new Secret("secret".Sha256()) },
                            AllowedScopes = { "Bridge.WebUIAPI", "openid", "profile" }
                        });
                    }).AddTestUsers(new List<TestUser>
                    {
                        new TestUser
                        {
                            SubjectId = "f26da293-02fb-4c90-be75-e4aa51e0bb17",
                            Username = "hamza@yopmail.com",
                            Password = "aA12345!",
                            Claims = new List<Claim>
                            {
                                new Claim(JwtClaimTypes.Email, "hamza@yopmail.com")
                            }
                        }
                    });
            }
            else
            {
                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, IdentityDbContext>();
            }

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}