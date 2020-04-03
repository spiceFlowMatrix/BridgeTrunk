using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Courses.Commands.AddEditCourseGrade
{
    public class AddEditCourseGradeCommandHandler : IRequestHandler<AddEditCourseGradeCommand, object>
    {
        public Task<object> Handle(AddEditCourseGradeCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}