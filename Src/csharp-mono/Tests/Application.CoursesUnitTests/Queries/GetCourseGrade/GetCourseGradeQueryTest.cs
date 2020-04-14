using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseGrade;
using Application.CoursesUnitTests.Common;
using Application.Helpers;
using Bridge.Persistence;
using Bridge.WebUI.Services;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourseGrade {
    [Collection ("QueryCollection")]

    public class GetCourseGradeQueryTest {
        private readonly BridgeDbContext _context;
        private readonly CurrentUserService _userService;
        public GetCourseGradeQueryTest (QueryTestFixture fixture) {
            _context = fixture.Context;
            _userService = fixture._userService;
        }

        [Fact]
        public async Task GetCourseGradeQueryHandlerTest () {
            var sut = new GetCourseGradeQueryHandler (_context, _userService);
            var result = await sut.Handle (new GetCourseGradeQuery { id = 1 }, CancellationToken.None);
            result.data.ShouldBeOfType<CourseGradeVm> ();
            result.ReturnCode.ShouldBe (200);
        }
    }
}