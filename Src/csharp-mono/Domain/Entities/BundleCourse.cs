using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class BundleCourse : AuditableEntity
    {        
        public long BundleId { get; set; }
        public long CourseId { get; set; }
    }
}
