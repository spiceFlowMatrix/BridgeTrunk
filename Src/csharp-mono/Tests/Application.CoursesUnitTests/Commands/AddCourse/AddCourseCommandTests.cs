using System;
using Xunit;
using Moq;
using MediatR;
using Application.CoursesUnitTests.Common;
using Application.Courses.Commands.AddCourse;
using Bridge.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CoursesUnitTests.Commands.AddCourse
{
    public class AddCourseCommandTests: CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldAddCourse()
        {
            // Arrange
            var sut = new AddCourseCommandHandler(_context, _userService);
            var obj = new AddCourseCommand 
            {
                Name = "abctest",
                Code = "001",
                Description = "test",
                Passmark = 10,
                GradeId = 1,
                BundleId = 1
            };

            // Act
            var response = await sut.Handle(obj, CancellationToken.None);

            // Assert
            Assert.True(response.ReturnCode == 200);
        }
        
    }
}