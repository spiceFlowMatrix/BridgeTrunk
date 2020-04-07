using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetAllCoursesDetail
{
    public class GetAllCoursesDetailQuery : IRequest<ApiResponse>
    {
        public int PageNumber { get; set; }
        public int PerPageRecord { get; set; }
        public int RoleId { get; set; }
        public string Search { get; set; }
        public string Filter { get; set; }
        public string ByGrade { get; set; }
    }
}