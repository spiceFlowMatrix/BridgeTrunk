using System;
using Bridge.Persistence;
using Bridge.WebUI.Services;

namespace Application.CoursesUnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly BridgeDbContext _context;
        protected readonly CurrentUserService _userService;
        public CommandTestBase()
        {
            _context = BridgeContextFactory.Create();
            _userService = new CurrentUserService(BridgeContextFactory.CreateHttpContext());
        }

        public void Dispose()
        {
            BridgeContextFactory.Destroy(_context);
        }
    }
}