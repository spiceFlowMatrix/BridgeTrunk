using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Courses.Commands.UpsertCourseGrade
{
    public class UpsertCourseGradeCommandHandler : IRequestHandler<UpsertCourseGradeCommand, object>
    {
        private readonly BridgeDbContext _dbContext;
        public UpsertCourseGradeCommandHandler(BridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
  
        public Task<object> Handle(UpsertCourseGradeCommand request, CancellationToken cancellationToken)
        {
            return "ok"; 
        }
    }
}