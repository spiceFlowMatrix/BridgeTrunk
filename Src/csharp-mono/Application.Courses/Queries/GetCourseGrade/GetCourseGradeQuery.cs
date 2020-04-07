using Bridge.Application.Models;
using MediatR;

namespace Application.Courses.Queries.GetCourseGrade
{
    public class GetCourseGradeQuery : IRequest<ApiResponse>
    {
        public int id { get; set; }
    }
}