using MediatR;
using Bridge.Application.Models;

namespace Application.Courses.Commands.AddCourseGrade
{
    public class AddCourseGradeCommand : IRequest<ApiResponse>
    {
        public long courseid { get; set; }
        public long gradeid { get; set; }
    }
}