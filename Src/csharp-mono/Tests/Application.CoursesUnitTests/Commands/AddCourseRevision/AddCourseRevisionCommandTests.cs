using Xunit;
using Application.CoursesUnitTests.Common;
using Application.Courses.Commands.AddCourseRevision;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.CoursesUnitTests.Commands.AddCourseRevision
{
    public class AddCourseRevisionCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldAddCourseRevision()
        {
            // Arrange
            var sut = new AddCourseRevisionCommandHandler(_context, _userService);
            var obj = new AddCourseRevisionCommand
            {
                RevisionName = "Initial Revision for Test Course",
                Summary = "Revision intended to add 5 Chapter to Course",
                CourseId = 1
            };

            // Act
            var response = await sut.Handle(obj, CancellationToken.None);

            // Assert
            Assert.True(response.ReturnCode == StatusCodes.Status200OK);
        }

    }
}