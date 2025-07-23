using MediatR;
using Microsoft.AspNetCore.Http;
using Bridge.Application.Models;

namespace Application.Courses.Commands.AddCourse
{
    public class AddCourseCommand: IRequest<ApiResponse>
    {
        public string FileName { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }   
        public long TeacherId { get; set; }    
        public int Culture { get; set; }
        public int Status { get; set; }
    }
}