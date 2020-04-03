using Bridge.Domain.Common;
using Bridge.Domain.Enums.Saas;

namespace Bridge.Domain.Entities.Saas
{
    public class Plan : AuditableEntity
    {
        public EPlanName PlanName { get; set; }

        public string SoftwareId { get; set; }
        public Software Software { get; set; }

        public string UserGroupTypeId { get; set; }
        public UserGroupType UserGroupType { get; set; }

        public decimal CurrentPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
