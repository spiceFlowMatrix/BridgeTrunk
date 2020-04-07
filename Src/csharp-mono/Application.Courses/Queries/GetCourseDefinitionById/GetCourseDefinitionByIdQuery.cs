using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetCourseDefinitionById
{
    public class GetCourseDefinitionByIdQuery: IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}