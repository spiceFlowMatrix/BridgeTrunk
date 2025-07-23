namespace Application.Courses.Queries.GetLessonByChapterId
{
    public class GetLessonsByChapterIdVm
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public string StatusName { get; set; }
        public int LessonType { get; set; }
        public string LessonTypeName { get; set; }

    }
}