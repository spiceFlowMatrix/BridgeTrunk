using MediatR;

namespace Application.Courses.Commands.AddEditCourseGrade
{
    public class AddEditCourseGradeCommand : IRequest<object>
    {
        public long courseid { get; set; }
        public long gradeid { get; set; }
    }
}