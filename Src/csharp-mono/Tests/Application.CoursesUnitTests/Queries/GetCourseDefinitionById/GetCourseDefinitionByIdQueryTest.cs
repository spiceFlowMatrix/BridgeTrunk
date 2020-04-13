using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseDefinitionById;
using Application.CoursesUnitTests.Common;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourseDefinitionById
{
    public class GetCourseDefinitionByIdQueryTest: CommandTestBase
    {
        [Fact]
        public async Task GetCourseDefinitionByIdQueryHandlerTest () {
            var sut = new GetCourseDefinitionByIdQueryHandler (_context);            
            var result = await sut.Handle (new GetCourseDefinitionByIdQuery{Id=1}, CancellationToken.None);                        
            result.data.ShouldBeOfType<CourseDefinitionVm>();          
            result.ReturnCode.ShouldBe (200);
        }
    }
}