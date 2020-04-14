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
                id =  1,
                name = "abctest",
                code = "001",
                description = "test",
                passmark = 10,
                gradeid = 1,
                bundleId = 1   
            };

            // Act
            var response = await sut.Handle(obj, CancellationToken.None);

            // Assert
            Assert.True(response.ReturnCode == 200);
        }
        
    }
}