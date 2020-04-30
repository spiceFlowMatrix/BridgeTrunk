using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetPaginatedCourse
{
    public class GetPaginatedCourseQuery: IRequest<ApiResponse>
    {
        public int pageNumber { get; set; }
        public int perPageRecord { get; set; }
        public string search { get; set; }
    }
}