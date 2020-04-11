using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Commands.DeleteCourseGrade;
using Application.CoursesUnitTests.Common;
using Xunit;

namespace Application.CoursesUnitTests.Commands.DeleteCourseGrade
{
    public class DeleteCourseGradeCommandTest : CommandTestBase {
        [Fact]
        public async Task AddCourseGradeCommandHandlerTest () {
            // Arrange
            var sut = new DeleteCourseGradeCommandHandler (_context, _userService);
            // Act
            var response = await sut.Handle (new DeleteCourseGradeCommand {
                id = 2
            }, CancellationToken.None);

            // Assert
            Assert.True (response.ReturnCode == 200);
        }

    }
}