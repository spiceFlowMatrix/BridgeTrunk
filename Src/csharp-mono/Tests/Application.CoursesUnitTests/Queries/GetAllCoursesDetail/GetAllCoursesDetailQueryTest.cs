using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetAllCoursesDetail;
using Application.CoursesUnitTests.Common;
using Microsoft.AspNetCore.Hosting;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetAllCoursesDetail
{
    public class GetAllCoursesDetailQueryTest: CommandTestBase
    {
        private readonly IHostingEnvironment _env;
      
        [Fact]
        public async Task GetCourseDefinationTest()
        {
            var sut = new GetAllCoursesDetailQueryHandler(_context,_userService,_userHelper,_env);

            var result = await sut.Handle(new GetAllCoursesDetailQuery {Filter = "1",
                ByGrade = "test",
                Search = "test",
                PageNumber = 1,
                PerPageRecord = 5 }, CancellationToken.None);

             result.data.ShouldBeOfType<List<GetAllCoursesDetailVm>>();

            result.ReturnCode.ShouldBe(200);
        }
    }
}