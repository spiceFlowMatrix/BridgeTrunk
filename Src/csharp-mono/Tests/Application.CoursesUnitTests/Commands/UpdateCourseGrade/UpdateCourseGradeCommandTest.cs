using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Commands.UpdateCourseGrade;
using Application.CoursesUnitTests.Common;
using Xunit;

namespace Application.CoursesUnitTests.Commands.UpdateCourseGrade {
    public class UpdateCourseGradeCommandTest : CommandTestBase {
        [Fact]
        public async Task AddCourseGradeCommandHandlerTest () {
            // Arrange
            var sut = new UpdateCourseGradeCommandHandler (_context, _userService);
            // Act
            var response = await sut.Handle (new UpdateCourseGradeCommand {
                id = 2,
                    courseid = 3,
                    gradeid = 1
            }, CancellationToken.None);

            // Assert
            Assert.True (response.ReturnCode == 200);
        }

    }
}