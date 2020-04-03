using MediatR;

namespace Application.Courses.Commands.UpsertCourseGrade
{
    public class UpsertCourseGradeCommand : IRequest<object>
    {
        public long courseid { get; set; }
        public long gradeid { get; set; }
    }
}