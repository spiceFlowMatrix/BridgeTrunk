using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetCourse
{
    public class GetCourseQuery: IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}