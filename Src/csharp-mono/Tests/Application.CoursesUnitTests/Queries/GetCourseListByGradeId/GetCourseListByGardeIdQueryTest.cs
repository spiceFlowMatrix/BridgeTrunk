using Xunit;
using Application.CoursesUnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Application.Courses.Queries.GetCourseListByGradeId;
using System.Collections.Generic;

namespace Application.CoursesUnitTests.Queries.GetCourseListByGradeId
{
    public class GetCourseListByGardeIdQueryTest: CommandTestBase {        

        [Fact]
        public async Task GetCourseListByGardeIdQueryHandlerTest () {
            var sut = new GetCourseListByGradeIdQueryHandler (_context);            
            var result = await sut.Handle (new GetCourseListByGradeIdQuery{PageNumber=1,PerPageRecord=5,Id=1}, CancellationToken.None);                        
            result.data.ShouldBeOfType<List<CourseListByGradeIdVm>>();          
            result.ReturnCode.ShouldBe (200);
        }
    }
}