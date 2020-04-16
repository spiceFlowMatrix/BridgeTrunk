using System.Text;
using Application.Authentication;
using Bridge.Application;
using Bridge.Application.Interfaces;
using Bridge.Infrastructure;
using Bridge.Persistence;
using Bridge.WebUI.Common;
using Bridge.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application.Courses;

namespace Bridge.WebUI
{
    public class Startup
    {
        private IServiceCollection _services;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration, Environment);
            services.AddPersistence(Configuration);
            services.AddApplication();
            services.AddApplicationCourses();
            services.AddApplicationAuthentication();

            services.AddHealthChecks()
                .AddDbContextCheck<BridgeDbContext>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddControllersWithViews()
                .AddNewtonsoftJson()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IBridgeDbContext>());

            services.AddRazorPages();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Bridge API";
                configure.AddSecurity("Bearer",
                new NSwag.OpenApiSecurityScheme
                {
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey
                });
            });

            _services = services;
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                RegisteredServicesPage(app);
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // TODO: Check if our reverse proxy infrastructure (kubernetes workload) handles hsts before deciding whether or not to remove hsts here. See https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-2.1&tabs=visual-studio#require-https
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCustomExceptionHandler();
            app.UseHealthChecks("/health");
            // TODO: Check if our reverse proxy infrastructure (kubernetes workload) handles httpsredirection before deciding whether or not to remove httpsredirection here. See https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-2.1&tabs=visual-studio#require-https
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (Environment.IsDevelopment() || Environment.IsEnvironment("Test"))
                {
                    // spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private void RegisteredServicesPage(IApplicationBuilder app)
        {
            app.Map("/services", builder => builder.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>Registered Services</h1>");
                sb.Append("<table><thead>");
                sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Instance</th></tr>");
                sb.Append("</thead><tbody>");
                foreach (var svc in _services)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append($"<td>{svc.Lifetime}</td>");
                    sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</tbody></table>");
                await context.Response.WriteAsync(sb.ToString());
            }));
        }
    }
}
