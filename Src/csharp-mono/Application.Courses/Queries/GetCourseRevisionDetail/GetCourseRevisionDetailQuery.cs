using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetCourseRevisionDetail {
    public class GetCourseRevisionDetailQuery : IRequest<ApiResponse> {
        public long RevisionId { get; set; }
    }
}