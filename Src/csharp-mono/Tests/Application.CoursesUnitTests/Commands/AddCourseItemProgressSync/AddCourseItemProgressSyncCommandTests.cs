using System;
using Xunit;
using Moq;
using MediatR;
using Application.CoursesUnitTests.Common;
using Bridge.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Commands.AddCourseItemProgressSync;
using System.Collections.Generic;

namespace Application.CoursesUnitTests.Commands.AddCourseItemProgressSync
{
    public class AddCourseItemProgressSyncCommandTests: CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldAddItemProgress()
        {
            // Arrange
            var sut = new AddCourseItemProgressSyncCommandHandler(_context, _userService);
            var obj = new AddCourseItemProgressSyncCommand 
            {
                addCourseItemProgressSyncs = new List<AddCourseItemProgressSyncModel>() {
                    new AddCourseItemProgressSyncModel{
                        lessonid = 1,
                        lessonprogress = 50,
                        quizid = 1
                    }
                }
            };

            // Act
            var response = await sut.Handle(obj, CancellationToken.None);

            // Assert
            Assert.True(response.ReturnCode == 200);
        }
        
    }
}