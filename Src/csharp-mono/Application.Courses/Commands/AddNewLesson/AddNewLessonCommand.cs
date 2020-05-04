using MediatR;

namespace Application.Courses.Commands.AddNewLesson
{
    public class AddNewLessonCommand: IRequest<object>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long? ChapterId { get; set; }
        public int? ItemOrder { get; set; }
        public int LessonType { get; set; }
        public int? Status { get; set; }
    }
}