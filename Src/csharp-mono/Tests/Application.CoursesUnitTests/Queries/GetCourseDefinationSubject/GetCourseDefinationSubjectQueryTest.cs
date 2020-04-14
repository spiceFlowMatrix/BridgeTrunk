using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseDefinitionSubject;
using Application.CoursesUnitTests.Common;
using Application.Helpers;
using Bridge.Persistence;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourseDefinationSubject
{
    [Collection("QueryCollection")]
    public class GetCourseDefinationSubjectQueryTest
    {
        private readonly BridgeDbContext _context;
        private readonly UserHelper _userHelper;

        public GetCourseDefinationSubjectQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _userHelper = fixture._userHelper;
        }
        [Fact]
        public async Task GetCourseDefinitionSubjectQueryHandlerTest()
        {
            var sut = new GetCourseDefinitionSubjectQueryHandler(_context);
            var result = await sut.Handle(new GetCourseDefinitionSubjectQuery { Search = "test" }, CancellationToken.None);
            result.data.ShouldBeOfType<List<CourseDefinationSubjectVm>>();
            result.ReturnCode.ShouldBe(200);
        }
    }
}