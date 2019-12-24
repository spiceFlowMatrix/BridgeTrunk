using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class UserGroup : AuditableEntity
    {
        public int UserGroupTypeId { get; set; }
        public UserGroupType UserGroupType { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
