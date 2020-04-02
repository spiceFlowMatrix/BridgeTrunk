using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bridge.Domain.Entities;
using Bridge.Persistence;

namespace Persistence
{
    public class DataInitializer
    {

        public static async Task Initialize(BridgeDbContext context)
        {
            await SeedEverything(context);
        }

        public static async Task SeedEverything(BridgeDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Role.Any())
            {
                await AddRoles(context);
            }

            if (!context.UserRole.Any())
            {
                await AddUserRole(context);
            }

            if (!context.Buckets.Any())
            {
                await AddBuckets(context);
            }

            if (!context.FeedBackTaskStatusOption.Any())
            {
                await AddFeedBackTaskStatusOption(context);
            }

            if (!context.FileTypes.Any())
            {
                await AddFileTypes(context);
            }

            if (!context.QuestionType.Any())
            {
                await AddQuestionType(context);
            }

            if (!context.DefaultValues.Any())
            {
                await AddDefaultValue(context);
            }

            if (!context.Users.Any())
            {
                await AddUser(context);
            }

            if (!context.LogObjectTypes.Any())
            {
                await AddLogObjectTypes(context);
            }

            if (!context.AddtionalServices.Any())
            {
                await AddAddtionalServices(context);
            }

            if (!context.TimeIntervals.Any())
            {
                await AddTimeInterval(context);
            }

            if (!context.SalesTax.Any())
            {
                await AddSalesTax(context);
            }

            if (!context.ERPAccounts.Any())
            {
                await AddERPAccounts(context);
            }

            if (!context.TaskCategoryFeedBacks.Any())
            {
                await AddTaskCategoryFeedBack(context);
            }

            if (!context.TaskActivityCategoryFeedBacks.Any())
            {
                await AddTaskActivityCategoryFeedBack(context);
            }

        }

        private static async Task AddRoles(BridgeDbContext context)
        {
            try
            {
                List<Role> list = new List<Role>
                {
                     new Role { Id = 1, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Administrator", RoleKey = "admin" },
                    new Role { Id = 2, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Analyst", RoleKey = "analyst" },
                    new Role { Id = 3, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Teacher", RoleKey = "teacher" },
                    new Role { Id = 4, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Student", RoleKey = "student" },
                    new Role { Id = 5, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Customer", RoleKey = "customer" },
                    new Role { Id = 6, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "AAF manager", RoleKey = "aaf_manager" },
                    new Role { Id = 7, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Coordinator", RoleKey = "coordinator" },
                    new Role { Id = 8, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Edit team leader", RoleKey = "edit_team_leader" },
                    new Role { Id = 9, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Shooting team leader", RoleKey = "shooting_team_leader" },
                    new Role { Id = 10, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Graphics team leader", RoleKey = "graphics_team_leader" },
                    new Role { Id = 11, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Quality assurance", RoleKey = "quality_assurance" },
                    new Role { Id = 12, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Feedback edge team", RoleKey = "feedback_edge_team" },
                    new Role { Id = 13, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Sales admin", RoleKey = "sales_admin" },
                    new Role { Id = 14, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Filming staff", RoleKey = "filming_staff" },
                    new Role { Id = 15, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Editing staff", RoleKey = "editing_staff" },
                    new Role { Id = 16, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Graphics staff", RoleKey = "graphics_staff" },
                    new Role { Id = 17, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Sales Agent", RoleKey = "sales_agent" },
                    new Role { Id = 18, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Parent", RoleKey = "parent" }
                };
                await context.Role.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddUserRole(BridgeDbContext context)
        {
            try
            {
                UserRole userRole = new UserRole
                {
                    Id = 1,
                    CreationTime = DateTime.Now.ToString(),
                    CreatorUserId = 1,
                    LastModificationTime = null,
                    DeleterUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    LastModifierUserId = null,
                    RoleId = 1,
                    UserId = 1
                };

                context.UserRole.Add(userRole);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddBuckets(BridgeDbContext context)
        {
            try
            {
                List<Buckets> list = new List<Buckets>
                {
                    new Buckets { Id = 1, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, BucketName = "core-api-sql-migrations" },
                    new Buckets { Id = 2, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, BucketName = "edg-primary-course-image-storage" },
                    new Buckets { Id = 3, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, BucketName = "edg-primary-profile-image-storage" },
                    new Buckets { Id = 4, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, BucketName = "edg-sales-primary-storage" },
                    new Buckets { Id = 5, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, BucketName = "eu.artifacts.training24-197210.appspot.com" },
                    new Buckets { Id = 6, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, BucketName = "t24-app-builds" },
                    new Buckets { Id = 7, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, BucketName = "t24-primary-audio-storage" },
                    new Buckets { Id = 8, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, BucketName = "t24-primary-image-storage" },
                    new Buckets { Id = 9, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, BucketName = "t24-primary-pdf-storage" },
                    new Buckets { Id = 10, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, BucketName = "t24-primary-video-storage" },
                    new Buckets { Id = 11, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, BucketName = "t24-secure-files" }
                };
                await context.Buckets.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddFeedBackTaskStatusOption(BridgeDbContext context)
        {
            try
            {
                List<FeedBackTaskStatusOption> list = new List<FeedBackTaskStatusOption>
                {
                   new FeedBackTaskStatusOption { Id = 1, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "UnApproved" },
                new FeedBackTaskStatusOption { Id = 2, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Approved" },
                new FeedBackTaskStatusOption { Id = 3, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Name = "Completed" }
                };
                await context.FeedBackTaskStatusOption.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddFileTypes(BridgeDbContext context)
        {
            try
            {
                List<FileTypes> list = new List<FileTypes>
                {
                    new FileTypes { Id = 1, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Filetype = "PDF" },
                    new FileTypes { Id = 2, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Filetype = "Video" },
                    new FileTypes { Id = 3, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Filetype = "Image" },
                    new FileTypes { Id = 4, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Filetype = "Zip" },
                    new FileTypes { Id = 5, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Filetype = "Audio" },
                    new FileTypes { Id = 6, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Filetype = "Xlsx" },
                    new FileTypes { Id = 7, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Filetype = "Docs" },
                    new FileTypes { Id = 8, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Filetype = "PPT" }
                };
                await context.FileTypes.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddQuestionType(BridgeDbContext context)
        {
            try
            {
                List<QuestionType> list = new List<QuestionType>
                {
                     new QuestionType { Id = 1, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Code = "MCQ" },
                    new QuestionType { Id = 2, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Code = "SA" },
                    new QuestionType { Id = 3, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Code = "nonmcq" },
                    new QuestionType { Id = 4, CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null, Code = "abc" }
                };
                await context.QuestionType.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddDefaultValue(BridgeDbContext context)
        {
            try
            {
                DefaultValues defaultValues = new DefaultValues
                {
                    Id = 1,
                    CreationTime = DateTime.Now.ToString(),
                    CreatorUserId = 1,
                    LastModificationTime = null,
                    DeleterUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    LastModifierUserId = null,
                    intervals = 3,
                    istimeouton = true,
                    reminder = 5,
                    timeout = 15
                };

                context.DefaultValues.Add(defaultValues);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddUser(BridgeDbContext context)
        {
            try
            {
                User defaultValues = new User
                {
                    Id = 1,
                    CreationTime = DateTime.Now.ToString(),
                    CreatorUserId = 1,
                    LastModificationTime = null,
                    DeleterUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    LastModifierUserId = null,
                    Username = "Admin",
                    FullName = "Admin",
                    Password = "F925916E2754E5E03F75DD58A5733251",
                    Email = "adminuser@email.com",
                    Bio = "string",
                    ProfilePicUrl = "https://www.googleapis.com/download/storage/v1/b/edg-primary-profile-image-storage/o/3_d279c045-9325-4cbb-bd31-16a40f70a080.png?generation=1540626401907278&alt=media",
                    IsBlocked = false,
                    is_skippable = true,
                    istimeouton = false,
                    reminder = 0,
                    timeout = 0,
                    intervals = 0,
                    phonenumber = null,
                    AuthId = "auth0|5c08a3afe9f0262e9378a9b2",
                    isfirstlogin = false
                };

                context.Users.Add(defaultValues);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddLogObjectTypes(BridgeDbContext context)
        {
            try
            {
                List<LogObjectTypes> list = new List<LogObjectTypes>
                {
                     new LogObjectTypes { Id = 1, EntityType = "Course", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 2, EntityType = "Course", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 3, EntityType = "Course", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 4, EntityType = "User", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 5, EntityType = "User", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 6, EntityType = "User", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 7, EntityType = "Chapter", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 8, EntityType = "Chapter", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 9, EntityType = "Chapter", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 10, EntityType = "Lesson", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 11, EntityType = "Lesson", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 12, EntityType = "Lesson", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 13, EntityType = "Quiz", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 14, EntityType = "Quiz", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 15, EntityType = "Quiz", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 16, EntityType = "Question", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 17, EntityType = "Question", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 18, EntityType = "Question", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 19, EntityType = "File", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 20, EntityType = "File", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 21, EntityType = "File", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 22, EntityType = "Notification", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 23, EntityType = "Notification", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 24, EntityType = "Notification", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 25, EntityType = "Discussion", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 26, EntityType = "Discussion", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 27, EntityType = "Discussion", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 28, EntityType = "Comment", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 29, EntityType = "Comment", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 30, EntityType = "Comment", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 31, EntityType = "DiscussionFile", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 32, EntityType = "DiscussionFile", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 33, EntityType = "DiscussionFile", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 34, EntityType = "CommentFile", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 35, EntityType = "CommentFile", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 36, EntityType = "CommentFile", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 37, EntityType = "AddtionalServices", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 38, EntityType = "AddtionalServices", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 39, EntityType = "AddtionalServices", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 40, EntityType = "Package", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 41, EntityType = "Package", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 42, EntityType = "Package", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 43, EntityType = "PackageCourse", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 44, EntityType = "PackageCourse", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 45, EntityType = "PackageCourse", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 46, EntityType = "BookAdd", Action = "Create", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 47, EntityType = "BookUpdate", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 48, EntityType = "BookDelete", Action = "Delete", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new LogObjectTypes { Id = 49, EntityType = "BookPublish", Action = "Update", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null }
                };
                await context.LogObjectTypes.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddAddtionalServices(BridgeDbContext context)
        {
            try
            {
                List<AddtionalServices> list = new List<AddtionalServices>
                {
                    new AddtionalServices { Id = 1, Name = "Homework", Price = "0", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new AddtionalServices { Id = 2, Name = "Discussion", Price = "0", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new AddtionalServices { Id = 3, Name = "Library", Price = "0", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new AddtionalServices { Id = 4, Name = "Parental Control", Price = "0", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null }
                };
                await context.AddtionalServices.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddTimeInterval(BridgeDbContext context)
        {
            try
            {
                TimeInterval timeInterval = new TimeInterval
                {
                    Id = 1,
                    Interval = 5,
                    CreationTime = DateTime.Now.ToString(),
                    CreatorUserId = 1,
                    LastModificationTime = null,
                    DeleterUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    LastModifierUserId = null
                };

                context.TimeIntervals.Add(timeInterval);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddSalesTax(BridgeDbContext context)
        {
            try
            {
                SalesTax salesTax = new SalesTax
                {
                    Id = 1,
                    Tax = 4,
                    CreationTime = DateTime.Now.ToString(),
                    CreatorUserId = 1,
                    LastModificationTime = null,
                    DeleterUserId = null,
                    DeletionTime = null,
                    IsDeleted = false,
                    LastModifierUserId = null
                };

                context.SalesTax.Add(salesTax);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddERPAccounts(BridgeDbContext context)
        {
            try
            {
                List<ERPAccounts> list = new List<ERPAccounts>
                {
                   new ERPAccounts { Id = 1, Type = 1, AccountCode = "", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new ERPAccounts { Id = 2, Type = 2, AccountCode = "", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new ERPAccounts { Id = 3, Type = 3, AccountCode = "", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new ERPAccounts { Id = 4, Type = 4, AccountCode = "", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null },
                    new ERPAccounts { Id = 5, Type = 5, AccountCode = "", CreationTime = DateTime.Now.ToString(), CreatorUserId = 1, LastModificationTime = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, LastModifierUserId = null }
                };
                await context.ERPAccounts.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddTaskCategoryFeedBack(BridgeDbContext context)
        {
            try
            {
                List<TaskCategoryFeedBack> list = new List<TaskCategoryFeedBack>
                {
                  new TaskCategoryFeedBack { Id = 1, CreationTime = DateTime.UtcNow.ToString(), CreatorUserId = 1, LastModificationTime = null, LastModifierUserId = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, Name = "Something Isn't Working in the App" },
                new TaskCategoryFeedBack { Id = 2, CreationTime = DateTime.UtcNow.ToString(), CreatorUserId = 1, LastModificationTime = null, LastModifierUserId = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, Name = "Video Issue" },
                new TaskCategoryFeedBack { Id = 3, CreationTime = DateTime.UtcNow.ToString(), CreatorUserId = 1, LastModificationTime = null, LastModifierUserId = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, Name = "Text Issue" },
                new TaskCategoryFeedBack { Id = 4, CreationTime = DateTime.UtcNow.ToString(), CreatorUserId = 1, LastModificationTime = null, LastModifierUserId = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, Name = "Lesson Assignment Issue" },
                new TaskCategoryFeedBack { Id = 5, CreationTime = DateTime.UtcNow.ToString(), CreatorUserId = 1, LastModificationTime = null, LastModifierUserId = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, Name = "Chapter Assignment Issue" },
                new TaskCategoryFeedBack { Id = 6, CreationTime = DateTime.UtcNow.ToString(), CreatorUserId = 1, LastModificationTime = null, LastModifierUserId = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, Name = "Quiz Issue" },
                new TaskCategoryFeedBack { Id = 7, CreationTime = DateTime.UtcNow.ToString(), CreatorUserId = 1, LastModificationTime = null, LastModifierUserId = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, Name = "General Feedback" }
                };
                await context.TaskCategoryFeedBacks.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static async Task AddTaskActivityCategoryFeedBack(BridgeDbContext context)
        {
            try
            {
                List<TaskActivityCategoryFeedBack> list = new List<TaskActivityCategoryFeedBack>
                {
                    new TaskActivityCategoryFeedBack { Id = 1, CreationTime = DateTime.UtcNow.ToString(), CreatorUserId = 1, LastModificationTime = null, LastModifierUserId = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, Name = "In Queue" },
                    new TaskActivityCategoryFeedBack { Id = 2, CreationTime = DateTime.UtcNow.ToString(), CreatorUserId = 1, LastModificationTime = null, LastModifierUserId = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, Name = "In Progress" },
                    new TaskActivityCategoryFeedBack { Id = 3, CreationTime = DateTime.UtcNow.ToString(), CreatorUserId = 1, LastModificationTime = null, LastModifierUserId = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, Name = "Completed" },
                    new TaskActivityCategoryFeedBack { Id = 4, CreationTime = DateTime.UtcNow.ToString(), CreatorUserId = 1, LastModificationTime = null, LastModifierUserId = null, DeleterUserId = null, DeletionTime = null, IsDeleted = false, Name = "Archived" }
                };
                await context.TaskActivityCategoryFeedBacks.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}