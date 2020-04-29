using MediatR;
using Microsoft.AspNetCore.Http;
using Bridge.Application.Models;

namespace Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<ApiResponse>
    {
        public UpdateCourseCommand()
        {
            BundleId = 0;
            Passmark = 0;
        }
        public int Id { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CultureId { get; set; }
        public long? TeacherId { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public decimal Passmark { get; set; }
        public long GradeId { get; set; }
        public long BundleId { get; set; }
        public bool IsTrial { get; set; }
    }
}