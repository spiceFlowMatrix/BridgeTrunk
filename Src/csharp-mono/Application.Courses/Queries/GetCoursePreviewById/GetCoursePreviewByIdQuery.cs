using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetCoursePreviewById
{
    public class GetCoursePreviewByIdQuery  : IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
    }
}