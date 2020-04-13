using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseDefinition;
using Application.CoursesUnitTests.Common;
using AutoMapper;
using Bridge.Persistence;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourseDefinition
{
    [Collection("QueryCollection")]
    public class GetCourseDefinitionQueryTests: CommandTestBase
    {
        [Fact]
        public async Task GetCourseDefinationTest()
        {
            var sut = new GetCourseDefinitionQueryHandler(_context);

            var result = await sut.Handle(new GetCourseDefinitionQuery { Pagenumber = 1, Perpagerecord = 5, Search = "Test" }, CancellationToken.None);

             result.data.ShouldBeOfType<List<CourseDefinitionVm>>();

            result.ReturnCode.ShouldBe(200);
        }

    }
}