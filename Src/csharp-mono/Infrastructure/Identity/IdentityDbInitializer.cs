using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Bridge.Infrastructure.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Bridge.Infrastructure.Identity
{
    public class IdentityDbInitializer
    {
        private const string AdminEmail = "hamza@yopmail.com";
        private const string AdminPassword = "aA123456!";

        private static readonly List<ApplicationRole> Roles = new List<ApplicationRole>()
        {
            new ApplicationRole {Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString()}
        };

        public static async Task SeedData(IdentityDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            dbContext.Database.EnsureCreated();

            if (!dbContext.Roles.Any())
            {
                await AddRoles(dbContext, roleManager);
            }
            if (!dbContext.Users.Any())
            {
                await AddUser(dbContext, userManager);
            }
            if (!dbContext.UserRoles.Any())
            {
                await AddUserRoles(dbContext, userManager);
            }
        }

        private static async Task<IdentityResult> AddRoles(IdentityDbContext dbContext, RoleManager<ApplicationRole> roleManager)
        {
            IdentityResult result = new IdentityResult();
            foreach (var role in Roles)
            {
               result= await roleManager.CreateAsync(role);
            }
            return result;
        }

        private static async Task<IdentityResult> AddUser(IdentityDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            var newuser = new ApplicationUser
            {
                UserName = AdminEmail,
                Email = AdminEmail,
                PhoneNumber = "5365425698"
            };
            return await userManager.CreateAsync(newuser, AdminPassword);
        }

        private static async Task<IdentityResult> AddUserRoles(IdentityDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            var user = await userManager.FindByEmailAsync(AdminEmail);
            return await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}