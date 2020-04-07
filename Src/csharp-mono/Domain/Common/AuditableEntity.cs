using System;

namespace Bridge.Domain.Common
{
    public class AuditableEntity
    {
        public long Id { get; set; }
        public int CreatorUserId { get; set; }

        public string CreationTime { get; set; }

        public int? LastModifierUserId { get; set; }

        public string LastModificationTime { get; set; }
    }
}