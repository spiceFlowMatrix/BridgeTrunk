using MediatR;
using Bridge.Application.Models;

namespace Application.Courses.Commands.AddCourseRevision
{
    public class AddCourseRevisionCommand: IRequest<ApiResponse>
    {
        public string RevisionName { get; set; }
        public string Summary { get; set; }
        public long CourseId { get; set; }
    }
}