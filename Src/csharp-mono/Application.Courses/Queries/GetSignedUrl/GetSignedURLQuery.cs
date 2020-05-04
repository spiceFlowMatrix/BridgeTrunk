using MediatR;

namespace Application.Courses.Queries.GetSignedUrl
{
    public class GetSignedURLQuery: IRequest<object>
    {
        public string ObjectName { get; set; }
        public string FileType { get; set; }
    }
}