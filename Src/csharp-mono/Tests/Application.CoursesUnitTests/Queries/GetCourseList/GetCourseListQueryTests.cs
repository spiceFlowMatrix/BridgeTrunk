using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseList;
using Application.CoursesUnitTests.Common;
using Application.Helpers;
using Bridge.Persistence;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourseList
{
    [Collection("QueryCollection")]
    public class GetCourseListQueryTests
    {
        private readonly BridgeDbContext _context;

        public GetCourseListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetCourseListTest()
        {
            var sut = new GetCourseListQueryHandler(_context);
            GetCourseListQuery query = new GetCourseListQuery
            {
                pagenumber = 1,
                perpagerecord = 5,
                search = "test"
            };

            var result = await sut.Handle(query, CancellationToken.None);

            result.ReturnCode.ShouldBe(200);
        }

    }
}