using System;
using Xunit;
using Moq;
using MediatR;
using Application.CoursesUnitTests.Common;
using Bridge.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Application.Courses.Commands.DeleteCourse;

namespace Application.CoursesUnitTests.Commands.DeleteCourse
{
    public class DeleteCourseCommandTests: CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldAddItemProgress()
        {
            // Arrange
            var sut = new DeleteCourseCommandHandler(_context, _userService);
            var obj = new DeleteCourseCommand
            {
                id = 1
            };

            // Act
            var response = await sut.Handle(obj, CancellationToken.None);

            // Assert
            Assert.True(response.ReturnCode == 200);
        }
        
    }
}