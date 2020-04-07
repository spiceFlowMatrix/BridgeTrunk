using MediatR;
using Microsoft.AspNetCore.Http;
using Bridge.Application.Models;

namespace Application.Courses.Commands.AddCourse
{
    public class AddCourseCommand: IRequest<ApiResponse>
    {
        public AddCourseCommand() {
            bundleId = 0;
            passmark = 0;
        }
        public string FileName { get; set; }
        public IFormFile file { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }       
        public decimal passmark { get; set; }
        public long gradeid { get; set; }
        public long bundleId { get; set; }
        public bool istrial { get; set; }
    }
}