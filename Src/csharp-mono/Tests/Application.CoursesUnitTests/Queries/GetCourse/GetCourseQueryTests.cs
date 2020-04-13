using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourse;
using Application.Courses.Queries.GetCourseDefinition;
using Application.CoursesUnitTests.Common;
using Application.Helpers;
using AutoMapper;
using Bridge.Persistence;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourse
{
    public class GetCourseQueryTests
    {
        private readonly BridgeDbContext _context;
        private readonly UserHelper _userHelper;

        public GetCourseQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetCourseTest()
        {
            // var sut = new GetCourseQueryHandler(_context);

            // var result = await sut.Handle(new GetCourseDefinitionQuery { Pagenumber = 1, Perpagerecord = 5, Search = "Test" }, CancellationToken.None);

            // // result.ShouldBeOfType<CourseDefinitionVm>();

            // result.ReturnCode.ShouldBe(200);
        }

    }
}