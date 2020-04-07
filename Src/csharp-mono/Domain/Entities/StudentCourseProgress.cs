using System;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class StudentCourseProgress : AuditableEntity
    {
        public long CourseId { get; set; }
        public long CourseStatus { get; set; }
        public decimal CourseProgress { get; set; }
        public long StudentId { get; set; }
    }
}
