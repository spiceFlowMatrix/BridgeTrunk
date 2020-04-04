using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class DocumentDetails : AuditableEntity
    {
        public string name { get; set; }
        public string DocumentUrl { get; set; }
    }
}