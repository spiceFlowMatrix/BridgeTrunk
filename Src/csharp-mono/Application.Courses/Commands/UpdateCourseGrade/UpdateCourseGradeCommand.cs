using MediatR;
using Bridge.Application.Models;

namespace Application.Courses.Commands.UpdateCourseGrade
{
    public class UpdateCourseGradeCommand : IRequest<ApiResponse>
    {
        public long id { get; set; }
        public long courseid { get; set; }
        public long gradeid { get; set; }
    }
}