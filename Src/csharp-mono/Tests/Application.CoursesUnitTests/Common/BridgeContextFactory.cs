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

            context.Course.AddRange (new [] {
                new Course {
                    Id = 1,
                        Name = "test",
                        Code = "test",
                        Description = "test",
                        Image = "test",
                        PassMark = (decimal) 9.9,
                        IsDeleted = false
                }, new Course {
                    Id = 2,
                        Name = "test2",
                        Code = "test2",
                        Description = "test2",
                        Image = "test2",
                        PassMark = (decimal) 9.9,
                        IsDeleted = false
                }, new Course {
                    Id = 3,
                        Name = "test3",
                        Code = "test3",
                        Description = "test3",
                        Image = "test3",
                        PassMark = (decimal) 9.9,
                        IsDeleted = false
                }, new Course {
                    Id = 4,
                        Name = "test4",
                        Code = "test4",
                        Description = "test4",
                        Image = "test4",
                        PassMark = (decimal) 9.9,
                        IsDeleted = false
                }, new Course {
                    Id = 5,
                        Name = "test5",
                        Code = "test5",
                        Description = "test5",
                        Image = "test5",
                        PassMark = (decimal) 9.9,
                        IsDeleted = false
                }, new Course {
                    Id = 6,
                        Name = "test6",
                        Code = "test6",
                        Description = "test6",
                        Image = "test6",
                        PassMark = (decimal) 9.9,
                        IsDeleted = false
                }, new Course {
                    Id = 7,
                        Name = "test7",
                        Code = "test7",
                        Description = "test7",
                        Image = "test7",
                        PassMark = (decimal) 9.9,
                        IsDeleted = false
                }
            });

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
                    Id = 1,
                        Name = "test",
                        Description = "test",
                        SchoolId = 1,
                        IsDeleted = false
                }, new Grade {
                    Id = 2,
                        Name = "testGrade",
                        Description = "testGrade",
                        SchoolId = 1,
                        IsDeleted = false
                }, new Grade {
                    Id = 3,
                        Name = "testGrade1",
                        Description = "testGrade1",
                        SchoolId = 1,
                        IsDeleted = false
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
            context.LessonProgresses.Add (new LessonProgress () {
                Id = 1,
                    ChapterId = 1,
                    LessonId = 1,
                    Progress = 50
            });

            context.Chapter.AddRange (new [] {
                new Chapter {
                    Id = 1,
                        Name = "test",
                        Code = "1",
                        CourseId = 1,
                        QuizId = 1,
                        ItemOrder = 1,
                        IsDeleted = false
                }, new Chapter {
                    Id = 2,
                        Name = "test2",
                        Code = "2",
                        CourseId = 1,
                        QuizId = 1,
                        ItemOrder = 1,
                        IsDeleted = false
                }
            });
            context.chapterQuiz.AddRange (new [] {
                new ChapterQuiz {
                    Id = 1,
                        ChapterId = 1,
                        QuizId = 1,
                        ItemOrder = 1,
                        IsDeleted = false
                }, new ChapterQuiz {
                    Id = 2,
                        ChapterId = 2,
                        QuizId = 2,
                        ItemOrder = 1,
                        IsDeleted = false
                }
            });
            context.Quiz.AddRange (new [] {
                new Quiz {
                    Id = 1,
                        Name = "test",
                        Code = "1",
                        NumQuestions = 4,
                        PassMark = 50,
                        TimeOut = 10,
                        ItemOrder = 1,
                        IsDeleted = false
                }, new Quiz {
                    Id = 2,
                        Name = "test2",
                        Code = "2",
                        NumQuestions = 4,
                        PassMark = 50,
                        TimeOut = 20,
                        ItemOrder = 1,
                        IsDeleted = false
                }
            });
            context.Assignment.AddRange (new [] {
                new Assignment {
                    Id = 1,
                        Name = "test",
                        Code = "1",
                        Description = "test",
                        ChapterId = 1,
                        ItemOrder = 1,
                        IsDeleted = false
                }, new Assignment {
                    Id = 2,
                        Name = "test2",
                        Code = "2",
                        Description = "test2",
                        ChapterId = 2,
                        ItemOrder = 1,
                        IsDeleted = false
                }
            });
            context.Lesson.AddRange (new [] {
                new Lesson {
                    Id = 1,
                        Name = "test",
                        Code = "1",
                        Description = "test",
                        ChapterId = 1,
                        ItemOrder = 1,
                        IsDeleted = false
                }, new Lesson {
                    Id = 2,
                        Name = "test2",
                        Code = "2",
                        Description = "test2",
                        ChapterId = 2,
                        ItemOrder = 1,
                        IsDeleted = false
                }
            });
            context.LessonAssignmentFiles.AddRange (new [] {
                new LessonAssignmentFile {
                    Id = 1,
                        FileId = 1,
                        AssignmentId = 1,
                        IsDeleted = false
                }, new LessonAssignmentFile {
                    Id = 2,
                        FileId = 1,
                        AssignmentId = 2,
                        IsDeleted = false
                }
            });
            context.Files.AddRange (new [] {
                new Files {
                    Id = 1,
                        Name = "test",
                        FileName = "test",
                        Description = "test",
                        Url = "test",
                        FileSize = 10,
                        FileTypeId = 1,
                        TotalPages = 5,
                        Duration = "test",
                        IsDeleted = false
                }, new Files {
                    Id = 2,
                        Name = "test2",
                        FileName = "test2",
                        Description = "test2",
                        Url = "test2",
                        FileSize = 10,
                        FileTypeId = 2,
                        TotalPages = 5,
                        Duration = "test2",
                        IsDeleted = false
                }
            });
            context.FileTypes.AddRange (new [] {
                new FileTypes {
                    Id = 1,
                        Filetype = "test",
                        IsDeleted = false
                }, new FileTypes {
                    Id = 2,
                        Filetype = "test2",
                        IsDeleted = false
                }
            });
            context.AssignmentFile.AddRange (new [] {
                new AssignmentFile {
                    Id = 1,
                        AssignmentId = 1,
                        FileId = 1,
                        IsDeleted = false
                }, new AssignmentFile {
                    Id = 2,
                        AssignmentId = 2,
                        FileId = 2,
                        IsDeleted = false
                }
            });
            context.LessonFile.AddRange (new [] {
                new LessonFile {
                    Id = 1,
                        LessionId = 1,
                        FileId = 1,
                        IsDeleted = false
                }, new LessonFile {
                    Id = 2,
                        LessionId = 2,
                        FileId = 2,
                        IsDeleted = false
                }
            });
            context.UserCourse.AddRange (new [] {
                new UserCourse {
                    Id = 1,
                        UserId = 1,
                        CourseId = 1,
                        StartDate = "02/02/2020",
                        EndDate = "05/05/2020",
                        IsExpire = false,
                        IsDeleted = false
                }, new UserCourse {
                    Id = 2,
                        UserId = 2,
                        CourseId = 2,
                        StartDate = "02/02/2020",
                        EndDate = "05/05/2020",
                        IsExpire = false,
                        IsDeleted = false
                }
            });
            context.Users.AddRange (new [] {
                new User {
                    Id = 1,
                        Username = "test",
                        FullName = "test",
                        Password = "test",
                        Email = "test",
                        Bio = "test",
                        ProfilePicUrl = "test",
                        IsBlocked = false,
                        is_skippable = false,
                        timeout = 10,
                        reminder = 10,
                        istimeouton = false,
                        intervals = 2,
                        phonenumber = "test",
                        AuthId = "test",
                        isfirstlogin = false,
                        isforgot = false,
                        forgotkey = "test",
                        is_discussion_authorized = false,
                        is_library_authorized = false,
                        is_assignment_authorized = false,
                        istrial = false,
                        isallowmap = false,
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