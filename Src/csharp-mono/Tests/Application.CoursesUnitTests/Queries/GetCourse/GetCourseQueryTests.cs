using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourse;
using Application.CoursesUnitTests.Common;
using Application.Helpers;
using Bridge.Persistence;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourse
{
    [Collection("QueryCollection")]
    public class GetCourseQueryTests
    {
        private readonly BridgeDbContext _context;
        private readonly UserHelper _userHelper;

        public GetCourseQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _userHelper = fixture._userHelper;
        }

        [Fact]
        public async Task GetCourseTest()
        {
            var sut = new GetCourseQueryHandler(_context, _userHelper);

            var result = await sut.Handle(new GetCourseQuery { id = 1 }, CancellationToken.None);

            result.ReturnCode.ShouldBe(200);
        }

    }
}