using System;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class CourseRevision : AuditableEntity
    {
        public string RevisionName { get; set; }
        public string Summary { get; set; }
        public string AdministeredOn { get; set; }
        public string AdministeredBy { get; set; }
        public string PublishedOn { get; set; }
        public string PublishedBy { get; set; }
        public string ReleasedOn { get; set; }
        public string ReleasedBy { get; set; }
        public int Status { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }
    }
}
