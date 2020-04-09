using System;

namespace Bridge.Domain.Common
{
    public class AuditableEntity
    {
        public long Id { get; set; }
        public string CreatorUserId { get; set; }

        public string CreationTime { get; set; }

        public string LastModifierUserId { get; set; }

        public string LastModificationTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string DeleterUserId { get; set; }
        public string DeletionTime { get; set; }
    }
}