using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Grade : AuditableEntity
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public long SchoolId { get; set; }
    }
}