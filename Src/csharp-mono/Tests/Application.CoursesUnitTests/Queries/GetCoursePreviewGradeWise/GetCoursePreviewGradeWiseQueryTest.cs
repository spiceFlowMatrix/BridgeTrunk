using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCoursePreviewGradeWise;
using Application.CoursesUnitTests.Common;
using Application.Interfaces;
using Bridge.Persistence;
using Bridge.WebUI.Services;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCoursePreviewGradeWise {
    [Collection ("QueryCollection")]
    public class GetCoursePreviewGradeWiseQueryTest {
        private readonly BridgeDbContext _context;
        private readonly CurrentUserService _userService;
        private readonly IUserHelper _userHelper;
        public GetCoursePreviewGradeWiseQueryTest (QueryTestFixture fixture) {
            _context = fixture.Context;
            _userService = fixture._userService;
            _userHelper = fixture._userHelper;
        }

        [Fact]
        public async Task GetCoursePreviewGradeWiseQueryHandlerTest () {
            var sut = new GetCoursePreviewGradeWiseQueryHandler (_context, _userHelper, _userService);
            var result = await sut.Handle (new GetCoursePreviewGradeWiseQuery {
                PageNumber = 1,
                    PerPageRecord = 5,
                    GradeId = 1,
                    Search = "t"
            }, CancellationToken.None);
            //return exception because of userId
            result.ReturnCode.ShouldBe (200);
        }
    }
}