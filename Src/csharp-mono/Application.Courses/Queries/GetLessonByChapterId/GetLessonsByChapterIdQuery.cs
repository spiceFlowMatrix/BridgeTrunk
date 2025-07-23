using MediatR;

namespace Application.Courses.Queries.GetLessonByChapterId
{
    public class GetLessonsByChapterIdQuery: IRequest<GetLessonsByChapterIdVm>
    {
        public long Id { get; set; }
    }
}