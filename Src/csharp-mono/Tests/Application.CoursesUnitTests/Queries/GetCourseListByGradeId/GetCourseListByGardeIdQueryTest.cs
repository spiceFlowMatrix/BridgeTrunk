using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseListByGradeId;
using Application.CoursesUnitTests.Common;
using Bridge.Persistence;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourseListByGradeId {
    [Collection ("QueryCollection")]
    public class GetCourseListByGardeIdQueryTest {
        private readonly BridgeDbContext _context;
        public GetCourseListByGardeIdQueryTest (QueryTestFixture fixture) {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetCourseListByGardeIdQueryHandlerTest () {
            var sut = new GetCourseListByGradeIdQueryHandler (_context);
            var result = await sut.Handle (new GetCourseListByGradeIdQuery { PageNumber = 1, PerPageRecord = 5, Id = 1 }, CancellationToken.None);
            result.data.ShouldBeOfType<List<CourseListByGradeIdVm>> ();
            result.ReturnCode.ShouldBe (200);
        }
    }
}