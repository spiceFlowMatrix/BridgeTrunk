using System;
using System.Collections.Generic;
using System.Linq;
using Bridge.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Bridge.Infrastructure.Identity
{
    public class IdentityDbInitializer
    {
        private const string AdminEmail = "hamza@yopmail.com";
        private const string AdminPassword = "aA123456!";

        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole {Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString()}
        };

        public static void SeedData(IdentityDbContext dbContext, IdentityUserManagerService userManager)
        {
            dbContext.Database.EnsureCreated();
            if (!dbContext.Roles.Any())
            {
                AddRoles(dbContext);
            }
            if (!dbContext.Users.Any())
            {
                AddUser(dbContext, userManager);
            }
            if (!dbContext.UserRoles.Any())
            {
                AddUserRoles(dbContext, userManager);
            }
        }

        private static void AddRoles(IdentityDbContext dbContext)
        {

            foreach (var role in Roles)
            {
                dbContext.Roles.Add(role);
                dbContext.SaveChanges();
            }
        }

        private static async void AddUser(IdentityDbContext dbContext, IdentityUserManagerService userManager)
        {
            await userManager.CreateUserAsync(AdminEmail, AdminPassword);
        }

        private static void AddUserRoles(IdentityDbContext dbContext, IdentityUserManagerService userManager)
        {

            var userRole = new IdentityUserRole<string>
            {
                UserId = dbContext.Users.Single(r => r.Email == AdminEmail).Id,
                RoleId = dbContext.Roles.Single(r => r.Name == "Admin").Id
            };
            dbContext.UserRoles.Add(userRole);
            dbContext.SaveChanges();
        }
    }
}