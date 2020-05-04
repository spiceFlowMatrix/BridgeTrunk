using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using MediatR;

namespace Application.Courses.Commands.AddNewLesson
{
    public class AddNewLessonCommandHandler : IRequestHandler<AddNewLessonCommand, object>
    {

        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        public AddNewLessonCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public Task<object> Handle(AddNewLessonCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}