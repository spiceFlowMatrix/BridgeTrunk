using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetCourseDefinition
{
    public class GetCourseDefinitionQuery : IRequest<ApiResponse>
    {
        public int Pagenumber { get; set; }
        public int Perpagerecord { get; set; }
        public int Roleid { get; set; }
        public string Search { get; set; }
        public int Total { get; set; }
    }
}