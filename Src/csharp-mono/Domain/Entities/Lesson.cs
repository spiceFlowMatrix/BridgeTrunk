using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Lesson : AuditableEntity
    {        
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public long? ChapterId { get; set; }
        public int ItemOrder { get; set; }
    }
}
