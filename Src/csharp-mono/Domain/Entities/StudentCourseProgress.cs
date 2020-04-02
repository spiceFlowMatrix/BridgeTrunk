using System;

namespace Bridge.Domain.Entities
{
    public class StudentCourseProgress : EntityBase
    {
        public long CourseId { get; set; }
        public long CourseStatus { get; set; }
        public decimal CourseProgress { get; set; }
        public long StudentId { get; set; }
    }
}
