using MediatR;
using Microsoft.AspNetCore.Http;
using Bridge.Application.Models;

namespace Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand: IRequest<ApiResponse>
    {
        public UpdateCourseCommand()
        {
            bundleId = 0;
            passmark = 0;
        }
        public int id { get; set; }
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