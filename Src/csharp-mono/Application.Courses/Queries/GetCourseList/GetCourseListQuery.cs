using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetCourseList
{
    public class GetCourseListQuery: IRequest<ApiResponse>
    {
        public int pageNumber { get; set; }
        public int perPageRecord { get; set; }
        public string search { get; set; }
    }
}