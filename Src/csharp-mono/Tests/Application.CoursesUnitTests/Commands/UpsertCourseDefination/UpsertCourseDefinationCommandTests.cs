using Application.CoursesUnitTests.Common;
using Application.Courses.Commands.UpsertCourseDefinition;
using MediatR;
using Moq;
using Xunit;
using Bridge.Application.Interfaces;
using Application.Interfaces;
using System.Threading;

namespace Application.CoursesUnitTests.Commands.UpsertCourseDefination
{
    public class UpsertCourseDefinationCommandTests : CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequest_ShouldCreateCourseDefination()
        {
            // Arrange
            var sut = new UpsertCourseDefinationCommandHandler(_context, _userService);

            // Act
            var response = sut.Handle(new UpsertCourseDefinationCommand
            {
                Id = 0,
                Subject = "Test",
                BasePrice = "123",
                GradeId = 1,
                CourseId = 1,
            }, CancellationToken.None);

            // Assert
            Assert.True(response.Result.ReturnCode == 200);
        }
        [Fact]
        public void Handle_GivenValidRequest_CheckForDuplicateCourseDefination()
        {
            // Arrange
            var sut = new UpsertCourseDefinationCommandHandler(_context, _userService);

            // Act
            var response = sut.Handle(new UpsertCourseDefinationCommand
            {
                Id = 1,
                Subject = "Test",
                BasePrice = "123",
                GradeId = 1,
                CourseId = 1,
            }, CancellationToken.None);

            // Assert
            Assert.True(response.Result.ReturnCode == 422);
        }
        [Fact]
        public void Handle_GivenValidRequest_ShouldUpdateCourseDefination()
        {
            // Arrange
            var sut = new UpsertCourseDefinationCommandHandler(_context, _userService);

            // Act
            var response = sut.Handle(new UpsertCourseDefinationCommand
            {
                Id = 1,
                Subject = "UpdatedTest",
                BasePrice = "123",
                GradeId = 1,
                CourseId = 1,
            }, CancellationToken.None);

            // Assert
            Assert.True(response.Result.ReturnCode == 200);
        }
    }
}