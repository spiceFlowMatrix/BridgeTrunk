using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseDefinition;
using Application.CoursesUnitTests.Common;
using Application.Helpers;
using AutoMapper;
using Bridge.Persistence;
using Microsoft.AspNetCore.Http;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourseDefinition
{
    [Collection("QueryCollection")]
    public class GetCourseDefinitionQueryTests
    {
        private readonly BridgeDbContext _context;
        private readonly UserHelper _userHelper;

        public GetCourseDefinitionQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _userHelper = fixture._userHelper;
        }
        [Fact]
        public async Task GetCourseDefinationTest()
        {
            var sut = new GetCourseDefinitionQueryHandler(_context);

            var result = await sut.Handle(new GetCourseDefinitionQuery { Pagenumber = 1, Perpagerecord = 5, Search = "Test" }, CancellationToken.None);

            result.data.ShouldBeOfType<List<CourseDefinitionVm>>();

            result.ReturnCode.ShouldBe(StatusCodes.Status200OK);
        }

    }
}