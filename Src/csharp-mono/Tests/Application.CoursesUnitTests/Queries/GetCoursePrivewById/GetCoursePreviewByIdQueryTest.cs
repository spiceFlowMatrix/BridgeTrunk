using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCoursePreviewById;
using Application.CoursesUnitTests.Common;
using Application.Interfaces;
using Bridge.Persistence;
using Rest.Courses.Services;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCoursePrivewById {
    [Collection ("QueryCollection")]
    public class GetCoursePreviewByIdQueryTest {
        private readonly BridgeDbContext _context;
        private readonly CurrentUserService _userService;
        private readonly IUserHelper _userHelper;
        public GetCoursePreviewByIdQueryTest (QueryTestFixture fixture) {
            _context = fixture.Context;
            _userService = fixture._userService;
            _userHelper = fixture._userHelper;
        }

        [Fact]
        public async Task GetCoursePreviewByIdQueryHandlerTest () {
            var sut = new GetCoursePreviewByIdQueryHandler (_context, _userService, _userHelper);
            var result = await sut.Handle (new GetCoursePreviewByIdQuery { Id = 1, StudentId = 0 }, CancellationToken.None);
            result.data.ShouldBeOfType<CoursePreviewVm> ();
            result.ReturnCode.ShouldBe (200);
        }
    }
}