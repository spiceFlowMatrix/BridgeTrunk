using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Commands.AddCourseGrade;
using Application.CoursesUnitTests.Common;
using Xunit;

namespace Application.CoursesUnitTests.Commands.AddCourseGrade
{
    public class AddCourseGradeCommandTest : CommandTestBase {
        [Fact]
        public async Task AddCourseGradeCommandHandlerTest () {
            // Arrange
            var sut = new AddCourseGradeCommandHandler (_context, _userService);
            // Act
            var response = await sut.Handle (new AddCourseGradeCommand {
                courseid = 3,
                    gradeid = 1
            }, CancellationToken.None);

            // Assert
            Assert.True (response.ReturnCode == 200);
        }

    }
}