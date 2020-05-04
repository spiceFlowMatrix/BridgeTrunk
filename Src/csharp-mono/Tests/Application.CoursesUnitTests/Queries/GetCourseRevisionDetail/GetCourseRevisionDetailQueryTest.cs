using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseRevisionDetail;
using Application.CoursesUnitTests.Common;
using Bridge.Persistence;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourseRevisionDetail {
    [Collection ("QueryCollection")]
    public class GetCourseRevisionDetailQueryTest {
        private readonly BridgeDbContext _context;

        public GetCourseRevisionDetailQueryTest (QueryTestFixture fixture) {
            _context = fixture.Context;
        }

        [Fact]
        public async Task Get_WhenCall_ReturnCode () {
            var sut = new GetCourseRevisionDetailQueryHandler (_context);
            GetCourseRevisionDetailQuery query = new GetCourseRevisionDetailQuery {
                RevisionId = 1
            };

            var result = await sut.Handle (query, CancellationToken.None);
            result.ReturnCode.ShouldBe (200);
        }

        [Fact]
        public async Task Get_WhenCall_ModelType () {
            var sut = new GetCourseRevisionDetailQueryHandler (_context);
            GetCourseRevisionDetailQuery query = new GetCourseRevisionDetailQuery {
                RevisionId = 1
            };

            var result = await sut.Handle (query, CancellationToken.None);
            result.data.ShouldBeOfType<CourseRevisionDetailVm> ();
        }
    }
}