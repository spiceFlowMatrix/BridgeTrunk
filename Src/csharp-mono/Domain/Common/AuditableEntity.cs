using System;

namespace Bridge.Domain.Common
{
    public class AuditableEntity
    {
        public long Id { get; set; }
        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}