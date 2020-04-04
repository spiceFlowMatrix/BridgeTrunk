using MediatR;
using Bridge.Application.Models;

namespace Application.Courses.Commands.UpsertCourseGrade
{
    public class UpsertCourseGradeCommand : IRequest<ApiResponse>
    {
        public long courseid { get; set; }
        public long gradeid { get; set; }
    }
}