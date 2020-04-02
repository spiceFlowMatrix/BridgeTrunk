using System;

namespace Bridge.Domain.Entities
{
    public class StudentLessonProgress : EntityBase
    {
        public long LessonId { get; set; }
        public long LessonStatus { get; set; }
        public long StudentId { get; set; }
        public decimal LessonProgress { get; set; }
        public long Duration { get; set; }
    }
}
