using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetCourseListByGradeId
{
    public class GetCourseListByGradeIdQuery  : IRequest<ApiResponse>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; }
        public int PerPageRecord { get; set; }
    }
}