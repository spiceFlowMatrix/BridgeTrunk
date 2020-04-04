using MediatR;
using Bridge.Application.Models;

namespace Application.Courses.Commands.DeleteCourseGrade
{
    public class DeleteCourseGradeCommand : IRequest<ApiResponse>
    {
        public int id { get; set; }
    }
}