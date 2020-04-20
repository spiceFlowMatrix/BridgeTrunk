using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Helpers;
using Application.Interfaces;

namespace Application.Courses
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationCourses(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IUserHelper), typeof(UserHelper));
            return services;
        }
    }
}
