using MediatR;
using Bridge.Application.Models;

namespace Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand: IRequest<ApiResponse>
    {
        public int id { get; set; }
    }
}