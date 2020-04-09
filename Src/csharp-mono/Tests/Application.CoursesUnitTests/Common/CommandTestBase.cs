using System;
using Bridge.Persistence;
namespace Application.CoursesUnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly BridgeDbContext _context;
        public CommandTestBase()
        {
            _context = BridgeContextFactory.Create();
        }

        public void Dispose()
        {
            BridgeContextFactory.Destroy(_context);
        }
    }
}