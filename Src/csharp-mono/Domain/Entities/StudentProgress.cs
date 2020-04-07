using System;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class StudentProgress : AuditableEntity
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
