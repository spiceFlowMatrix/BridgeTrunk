using System;

namespace Bridge.Domain.Common
{
    public class AuditableEntity
    {
        public string EntityId { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}