using MediatR;
using Microsoft.AspNetCore.Http;
using Bridge.Application.Models;

namespace Application.Courses.Commands.AddCourse
{
    public class AddCourseCommand: IRequest<ApiResponse>
    {
        public AddCourseCommand() {
            BundleId = 0;
            Passmark = 0;
        }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }   
        public long? TeacherId { get; set; }    
        public int CultureId { get; set; }
        public int Status { get; set; }
        public decimal Passmark { get; set; }
        public long GradeId { get; set; }
        public long BundleId { get; set; }
        public bool isTrial { get; set; }
    }
}