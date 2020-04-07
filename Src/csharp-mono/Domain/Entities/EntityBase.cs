using System;

namespace Bridge.Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }

        public string CreationTime { get; set; }
        public int? CreatorUserId { get; set; }
        public string LastModificationTime { get; set; }
        public int? LastModifierUserId { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeleterUserId { get; set; }
        public string DeletionTime { get; set; }
    }
}
