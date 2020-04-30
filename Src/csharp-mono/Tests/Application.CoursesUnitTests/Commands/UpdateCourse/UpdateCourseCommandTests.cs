using System;
using Xunit;
using Moq;
using MediatR;
using Application.CoursesUnitTests.Common;
using Bridge.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Application.Courses.Commands.UpdateCourse;

namespace Application.CoursesUnitTests.Commands.UpdateCourse
{
    public class UpdateCourseCommandTests: CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldUpdateCourse()
        {
            // Arrange
            var sut = new UpdateCourseCommandHandler(_context, _userService);
            var obj = new UpdateCourseCommand 
            {
                Id =  1,
                Name = "abctest",
                Code = "001",
                Description = "test",
                Status= 1
            };

            // Act
            var response = await sut.Handle(obj, CancellationToken.None);

            // Assert
            Assert.True(response.ReturnCode == 200);
        }
        
    }
}