using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetPaginatedCourse;
using Application.CoursesUnitTests.Common;
using Application.Helpers;
using Bridge.Persistence;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetPaginatedCourse
{
    [Collection("QueryCollection")]
    public class GetPaginatedCourseQueryTests
    {
        private readonly BridgeDbContext _context;
        private readonly UserHelper _userHelper;

        public GetPaginatedCourseQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _userHelper = fixture._userHelper;
        }

        [Fact]
        public async Task GetPaginatedCourseTest()
        {
            var sut = new GetPaginatedCourseQueryHandler(_context, _userHelper);
            GetPaginatedCourseQuery query = new GetPaginatedCourseQuery
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