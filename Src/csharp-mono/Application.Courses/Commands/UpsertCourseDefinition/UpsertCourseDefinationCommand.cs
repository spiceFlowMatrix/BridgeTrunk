using Bridge.Application.Models;
using MediatR;
namespace Application.Courses.Commands.UpsertCourseDefinition
{
    public class UpsertCourseDefinationCommand : IRequest<ApiResponse>
    {
        public long GradeId { get; set; }
        public long CourseId { get; set; }
        public string Subject { get; set; }
        public string BasePrice { get; set; }
        public long? Id { get; set; }
    }
}