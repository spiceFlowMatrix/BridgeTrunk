using Xunit;
using Application.CoursesUnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseGrade;
using Shouldly;

namespace Application.CoursesUnitTests.Queries.GetCourseGrade
{
    public class GetCourseGradeQueryTest: CommandTestBase {        

        [Fact]
        public async Task GetCourseGradeQueryHandlerTest () {
            var sut = new GetCourseGradeQueryHandler (_context,_userService);            
            var result = await sut.Handle (new GetCourseGradeQuery{id=1}, CancellationToken.None);                        
            result.data.ShouldBeOfType<CourseGradeVm>();          
            result.ReturnCode.ShouldBe (200);
        }
    }
}