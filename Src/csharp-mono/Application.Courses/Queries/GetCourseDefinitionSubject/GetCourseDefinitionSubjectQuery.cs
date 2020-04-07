using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetCourseDefinitionSubject
{
    public class GetCourseDefinitionSubjectQuery: IRequest<ApiResponse>
    {
        public string Search { get; set; }
    }
}