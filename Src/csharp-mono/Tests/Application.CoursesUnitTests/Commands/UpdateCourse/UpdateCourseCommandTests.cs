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
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Application.CoursesUnitTests.Commands.UpdateCourse
{
    public class UpdateCourseCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldUpdateCourse()
        {
            // Arrange
            var sut = new UpdateCourseCommandHandler(_context, _userService);
            var obj = new UpdateCourseCommand
            {
                Id = 1,
                Name = "abctest",
                Code = "001",
                Description = "test",
                Status = 1,
                TeacherId = 1,
                Culture = 1
            };

            // Act
            var response = await sut.Handle(obj, CancellationToken.None);

            // Assert
            Assert.True(response.ReturnCode == StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldNotFoundCourse()
        {
            // Arrange
            var sut = new UpdateCourseCommandHandler(_context, _userService);
            var obj = new UpdateCourseCommand
            {
                Id = 10,
                Name = "abctest",
                Code = "001",
                Description = "test",
                Status = 1,
                TeacherId = 1,
                Culture = 1
            };

            // Act
            var response = await sut.Handle(obj, CancellationToken.None);

            // Assert
            Assert.True(response.ReturnCode == StatusCodes.Status404NotFound);
        }

    }
}