using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetCourseList
{
    public class GetCourseListQuery: IRequest<ApiResponse>
    {
        public int pagenumber { get; set; }
        public int perpagerecord { get; set; }
        public string search { get; set; }
    }
}