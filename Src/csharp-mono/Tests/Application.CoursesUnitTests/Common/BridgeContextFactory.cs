using System;
using Microsoft.EntityFrameworkCore;
using Bridge.Domain.Entities;
using Bridge.Persistence;

namespace Application.CoursesUnitTests.Common
{
    public class BridgeContextFactory
    {
        public static BridgeDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BridgeDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new BridgeDbContext(options);

            context.Database.EnsureCreated();

            context.CourseDefination.AddRange(new[] {
                new CourseDefination { CreationTime = DateTime.UtcNow.ToString(),
                                CreatorUserId = "1",
                                Subject = "test",
                                BasePrice = "123",
                                GradeId = 1},
                new CourseDefination { CreationTime = DateTime.UtcNow.ToString(),
                                CreatorUserId = "1",
                                Subject = "new",
                                BasePrice = "123",
                                GradeId = 1,
                                CourseId = 1 },
                 new CourseDefination { CreationTime = DateTime.UtcNow.ToString(),
                                CreatorUserId = "1",
                                Subject = "newtest",
                                BasePrice = "123",
                                GradeId = 1,
                                CourseId = 1 }

                    });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(BridgeDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}