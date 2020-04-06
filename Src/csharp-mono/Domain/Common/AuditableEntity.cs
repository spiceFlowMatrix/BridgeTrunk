using System;

namespace Bridge.Domain.Common
{
    public class AuditableEntity
    {
        public long Id { get; set; }
        public int CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public int? LastModifierUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}