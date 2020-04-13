using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseDefinitionSubject;
using Application.CoursesUnitTests.Common;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourseDefinationSubject
{
    public class GetCourseDefinationSubjectQueryTest: CommandTestBase
    {
        [Fact]
        public async Task GetCourseDefinitionSubjectQueryHandlerTest () {
            var sut = new GetCourseDefinitionSubjectQueryHandler (_context);            
            var result = await sut.Handle (new GetCourseDefinitionSubjectQuery{Search = "test"}, CancellationToken.None);                        
            result.data.ShouldBeOfType<List<CourseDefinationSubjectVm>>();          
            result.ReturnCode.ShouldBe(200);
        }
    }
}