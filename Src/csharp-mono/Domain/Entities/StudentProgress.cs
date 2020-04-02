using System;

namespace Bridge.Domain.Entities
{
    public class StudentProgress : EntityBase
    {
        public long CourseId { get; set; }
        public long ChapterId { get; set; }
        public long LessonId { get; set; }
        public long CourseStatus { get; set; }
        public long ChapterStatus { get; set; }
        public long LessonStatus { get; set; }
        public decimal CourseProgress { get; set; }
        public long StudentId { get; set; }
    }
}
