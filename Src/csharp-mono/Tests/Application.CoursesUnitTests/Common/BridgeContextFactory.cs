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
                                GradeId = 1,
                                IsDeleted = false},
                new CourseDefination { CreationTime = DateTime.UtcNow.ToString(),
                                CreatorUserId = "1",
                                Subject = "new",
                                BasePrice = "123",
                                GradeId = 1,
                                CourseId = 1,
                                IsDeleted = false },
                 new CourseDefination { CreationTime = DateTime.UtcNow.ToString(),
                                CreatorUserId = "1",
                                Subject = "newtest",
                                BasePrice = "123",
                                GradeId = 1,
                                CourseId = 1,
                                IsDeleted = false }

                    });

            context.Course.AddRange(new[] {
               new Course{
                   Name = "test",
                   Description = "testDes",
                   Code = "testcode",
                   IsDeleted = false
               },
               new Course{
                   Name = "testName",
                   Description = "test",
                   Code = "test",IsDeleted = false
               },
               new Course{
                   Name = "testNameNew ",
                   Description = "testDesn",
                   Code = "testcodeN",IsDeleted = false
               }
            });
            context.Grade.AddRange(new[]{
                new Grade {
                    Name = "test",
                    Description = "test",
                    SchoolId = 1,IsDeleted = false
                }, new Grade {
                    Name = "testGrade",
                    Description = "testGrade",
                    SchoolId = 1,IsDeleted = false
                }, new Grade {
                    Name = "testGrade1",
                    Description = "testGrade1",
                    SchoolId = 1,IsDeleted = false
                },
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