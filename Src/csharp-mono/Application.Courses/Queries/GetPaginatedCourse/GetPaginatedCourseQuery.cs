using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetPaginatedCourse
{
    public class GetPaginatedCourseQuery: IRequest<ApiResponse>
    {
        public int pagenumber { get; set; }
        public int perpagerecord { get; set; }
        public string search { get; set; }
    }
}