using System;
using System.Security.Claims;
using System.Security.Principal;
using Bridge.Domain.Entities;
using Bridge.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Application.CoursesUnitTests.Common {
    public class BridgeContextFactory {
        public static BridgeDbContext Create () {
            var options = new DbContextOptionsBuilder<BridgeDbContext> ()
                .UseInMemoryDatabase (Guid.NewGuid ().ToString ())
                .Options;

            var context = new BridgeDbContext (options);

            context.Database.EnsureCreated ();

            context.CourseDefination.AddRange (new [] {
                new CourseDefination {
                    CreationTime = DateTime.UtcNow.ToString (),
                        CreatorUserId = "1",
                        Subject = "test",
                        BasePrice = "123",
                        GradeId = 1,
                        CourseId = 1,
                        IsDeleted = false
                },
                new CourseDefination {
                    CreationTime = DateTime.UtcNow.ToString (),
                        CreatorUserId = "1",
                        Subject = "new",
                        BasePrice = "123",
                        GradeId = 1,
                        CourseId = 1,
                        IsDeleted = false
                },
                new CourseDefination {
                    CreationTime = DateTime.UtcNow.ToString (),
                        CreatorUserId = "1",
                        Subject = "newtest",
                        BasePrice = "123",
                        GradeId = 1,
                        CourseId = 1,
                        IsDeleted = false
                }
            });

            context.School.Add (new School {
                Id = 1,
                    Code = "001",
                    Name = "Abc",
                    IsDeleted = false
            });

            context.Grade.AddRange (new [] {
                new Grade {
                    Name = "test",
                        Description = "test",
                        SchoolId = 1, IsDeleted = false
                }, new Grade {
                    Name = "testGrade",
                        Description = "testGrade",
                        SchoolId = 1, IsDeleted = false
                }, new Grade {
                    Name = "testGrade1",
                        Description = "testGrade1",
                        SchoolId = 1, IsDeleted = false
                },
            });
            context.CourseGrade.AddRange (new [] {
                new CourseGrade {
                    Id = 1,
                        CourseId = 1,
                        Gradeid = 1,
                        IsDeleted = false
                }, new CourseGrade {
                    Id = 2,
                        CourseId = 2,
                        Gradeid = 1,
                        IsDeleted = false
                }
            });
            context.Course.AddRange (new [] {
                new Course {
                    Id = 1,
                        Name = "Test",
                        Code = "Test",
                        Description = "Test",
                        Image = "Test",
                        PassMark = (decimal) 9.9,
                        istrial = false,
                        IsDeleted = false
                }, new Course {
                    Id = 2,
                        Name = "Test2",
                        Code = "Test2",
                        Description = "Test2",
                        Image = "Test2",
                        PassMark = (decimal) 9.9,
                        istrial = false,
                        IsDeleted = false
                }
            });
            context.SaveChanges ();

            return context;
        }

        public static HttpContextAccessor CreateHttpContext () {
            var userIdClaim = new Mock<Claim> (ClaimTypes.NameIdentifier, "auth0|test123456");
            var roleClaim = new Mock<Claim> (ClaimTypes.Role, "Admin");

            var httpContextAccessor = new Mock<HttpContextAccessor> ();
            var httpContext = new Mock<HttpContext> ();
            var fakeIdentity = new GenericIdentity ("User");
            var principal = new GenericPrincipal (fakeIdentity, new String[] { "Admin" });

            httpContext.Setup (t => t.User).Returns (principal);
            //httpContextAccessor.SetupProperty(_=>_.HttpContext).Setup(_=>_.HttpContext).Returns(httpContext.Object);
            // httpContextAccessor.Setup(_ => _.HttpContext).Returns(httpContext.Object);
            // httpContextAccessor.SetupSet(_ => _.HttpContext.User = new Mock<ClaimsPrincipal>().Object);
            //httpContextAccessor.SetupSet(_ => _.HttpContext.User.Claims = new List<Claim> { userIdClaim.Object, roleClaim.Object }).Returns(new List<Claim> { userIdClaim.Object, roleClaim.Object });
            return httpContextAccessor.Object;
        }
        public static void Destroy (BridgeDbContext context) {
            context.Database.EnsureDeleted ();

            context.Dispose ();
        }
    }
}