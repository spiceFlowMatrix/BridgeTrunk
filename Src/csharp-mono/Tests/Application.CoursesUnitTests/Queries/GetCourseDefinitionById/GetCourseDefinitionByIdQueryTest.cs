using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseDefinitionById;
using Application.CoursesUnitTests.Common;
using Application.Helpers;
using Bridge.Persistence;
using Microsoft.AspNetCore.Http;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourseDefinitionById
{
    [Collection("QueryCollection")]
    public class GetCourseDefinitionByIdQueryTest
    {
        private readonly BridgeDbContext _context;
        private readonly UserHelper _userHelper;

        public GetCourseDefinitionByIdQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _userHelper = fixture._userHelper;
        }
        [Fact]
        public async Task GetCourseDefinitionByIdQueryHandlerTest()
        {
            var sut = new GetCourseDefinitionByIdQueryHandler(_context);
            var result = await sut.Handle(new GetCourseDefinitionByIdQuery { Id = 1 }, CancellationToken.None);
            result.data.ShouldBeOfType<CourseDefinitionVm>();
            result.ReturnCode.ShouldBe(StatusCodes.Status200OK);
        }
    }
}