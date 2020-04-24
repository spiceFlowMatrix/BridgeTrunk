using System;
using Application.Helpers;
using Application.Interfaces;
using Bridge.Persistence;
using Rest.Courses.Services;

namespace Application.CoursesUnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly BridgeDbContext _context;
        protected readonly CurrentUserService _userService;
        protected readonly IUserHelper _userHelper;
        public CommandTestBase()
        {
            _context = BridgeContextFactory.Create();
            _userService = new CurrentUserService(BridgeContextFactory.CreateHttpContext());
            _userHelper = new UserHelper(_context);
        }

        public void Dispose()
        {
            BridgeContextFactory.Destroy(_context);
        }
    }
}