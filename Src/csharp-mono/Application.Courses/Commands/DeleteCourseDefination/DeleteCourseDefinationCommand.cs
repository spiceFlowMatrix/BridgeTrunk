using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Commands.DeleteCourseDefination
{
    public class DeleteCourseDefinationCommand: IRequest<ApiResponse>
    {
        public  int Id { get; set; }
    }
}