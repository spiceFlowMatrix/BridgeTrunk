using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCoursePreviewGradeWise;
using Application.CoursesUnitTests.Common;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCoursePreviewGradeWise {
    public class GetCoursePreviewGradeWiseQueryTest : CommandTestBase {

        [Fact]
        public async Task GetCoursePreviewGradeWiseQueryHandlerTest () {
            var sut = new GetCoursePreviewGradeWiseQueryHandler (_context, _userHelper, _userService);
            var result = await sut.Handle (new GetCoursePreviewGradeWiseQuery {
                PageNumber = 1,
                    PerPageRecord = 5,
                    GradeId = 1,
                    Search = "A"
            }, CancellationToken.None);
            result.data.ShouldBeOfType<object> ();
            result.ReturnCode.ShouldBe (200);
        }
    }
}