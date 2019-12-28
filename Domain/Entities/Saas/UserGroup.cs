using Bridge.Domain.Common;

namespace Bridge.Domain.Entities.Saas
{
    public class UserGroup : AuditableEntity
    {
        public UserGroupType UserGroupType { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
