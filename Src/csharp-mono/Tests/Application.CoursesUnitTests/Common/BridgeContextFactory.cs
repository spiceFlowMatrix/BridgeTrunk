using System;
using Microsoft.EntityFrameworkCore;
using Bridge.Domain.Entities;
using Bridge.Persistence;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using System.Collections.Generic;
using System.Security.Principal;

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
                context.Grade.Add(new Grade
                {
                    Id = 1,
                    Name = "Test",
                    Description = "test",
                    SchoolId = 1,
                    IsDeleted = false
                });

                context.School.Add(new School
                {
                    Id = 1,
                    Code = "001",
                    Name = "Abc",
                    IsDeleted = false
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

        public static HttpContextAccessor CreateHttpContext() 
        {
            var userIdClaim = new Mock<Claim>(ClaimTypes.NameIdentifier, "auth0|test123456");
            var roleClaim =  new Mock<Claim>(ClaimTypes.Role, "Admin");

            var httpContextAccessor = new Mock<HttpContextAccessor>();
            var httpContext = new Mock<HttpContext>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, new String[]{"Admin"});

            httpContext.Setup(t => t.User).Returns(principal);
            //httpContextAccessor.SetupProperty(_=>_.HttpContext).Setup(_=>_.HttpContext).Returns(httpContext.Object);
            // httpContextAccessor.Setup(_ => _.HttpContext).Returns(httpContext.Object);
            // httpContextAccessor.SetupSet(_ => _.HttpContext.User = new Mock<ClaimsPrincipal>().Object);
            //httpContextAccessor.SetupSet(_ => _.HttpContext.User.Claims = new List<Claim> { userIdClaim.Object, roleClaim.Object }).Returns(new List<Claim> { userIdClaim.Object, roleClaim.Object });
            return httpContextAccessor.Object;
        }
        public static void Destroy(BridgeDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}