using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetCoursePreviewGradeWise
{
    public class GetCoursePreviewGradeWiseQuery : IRequest<ApiResponse>
    {
        public int PageNumber { get; set; }
        public int PerPageRecord { get; set; }
        public string Search { get; set; }
        public int GradeId { get; set; }
    }
}