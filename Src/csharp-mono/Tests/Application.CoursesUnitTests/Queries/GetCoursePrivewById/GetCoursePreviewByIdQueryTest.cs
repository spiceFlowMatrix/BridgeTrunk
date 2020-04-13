using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCoursePreviewById;
using Application.CoursesUnitTests.Common;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCoursePrivewById {
    public class GetCoursePreviewByIdQueryTest : CommandTestBase {

        [Fact]
        public async Task GetCoursePreviewByIdQueryHandlerTest () {
            var sut = new GetCoursePreviewByIdQueryHandler (_context, _userService, _userHelper);
            var result = await sut.Handle (new GetCoursePreviewByIdQuery { Id = 1, StudentId = 0 }, CancellationToken.None);
            result.data.ShouldBeOfType<CoursePreviewVm> ();
            result.ReturnCode.ShouldBe (200);
        }
    }
}