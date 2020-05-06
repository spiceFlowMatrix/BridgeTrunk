
using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Commands.DeleteCourseDefination;
using Application.CoursesUnitTests.Common;
using Application.Interfaces;
using Bridge.Application.Exceptions;
using Bridge.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Application.CoursesUnitTests.Commands.DeleteCourseDefination
{
    public class DeleteCourseDefinationCommandTest : CommandTestBase
    {
        private readonly DeleteCourseDefinationCommandHandler _sut;
        public DeleteCourseDefinationCommandTest()
            : base()
        {
            _sut = new DeleteCourseDefinationCommandHandler(_context, _userService, _userHelper);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ThrowsNotFoundException()
        {
            var invalidId = 5;
            var command = new DeleteCourseDefinationCommand { Id = invalidId };
            var noDataFound = await _sut.Handle(command, CancellationToken.None);
            Assert.True(noDataFound.ReturnCode == 400);
            
        }

        [Fact]
        public async Task Handle_GivenValidIdAndZeroOrders_DeleteCourseDefination()
        {
            var validId = 1;
            var command = new DeleteCourseDefinationCommand { Id = validId };
            var response = await _sut.Handle(command, CancellationToken.None);
            Assert.True(response.ReturnCode == StatusCodes.Status200OK);
        }

    }
}