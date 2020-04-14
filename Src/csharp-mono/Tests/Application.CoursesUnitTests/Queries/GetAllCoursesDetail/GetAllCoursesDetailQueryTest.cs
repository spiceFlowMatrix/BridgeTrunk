using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetAllCoursesDetail;
using Application.CoursesUnitTests.Common;
using Application.Helpers;
using Bridge.Application.Interfaces;
using Bridge.Persistence;
using Microsoft.AspNetCore.Hosting;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetAllCoursesDetail
{
    [Collection("QueryCollection")]
    public class GetAllCoursesDetailQueryTest 
    {
        private readonly BridgeDbContext _context;
        private readonly UserHelper _userHelper;
        private readonly ICurrentUserService _userService;
        private readonly IHostingEnvironment _env;


        public GetAllCoursesDetailQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _userHelper = fixture._userHelper;
        }

        [Fact]
        public async Task GetCourseDefinationTest()
        {
            var sut = new GetAllCoursesDetailQueryHandler(_context, _userService, _userHelper, _env);

            var result = await sut.Handle(new GetAllCoursesDetailQuery
            {
                Filter = "1",
                ByGrade = "test",
                Search = "test",
                PageNumber = 1,
                PerPageRecord = 5
            }, CancellationToken.None);

            // result.data.ShouldBeOfType<List<GetAllCoursesDetailVm>>();

            result.ReturnCode.ShouldBe(200);
        }
    }
}