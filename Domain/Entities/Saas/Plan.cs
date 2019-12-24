using Bridge.Domain.Enums;

namespace Bridge.Domain.Entities.Saas
{
    public class Plan
    {
        public int Id { get; set; }
        public EPlanNames PlanName { get; set; }

        public int SoftwareId { get; set; }
        public Software Software { get; set; }

        public int UserGroupTypeId { get; set; }
        public UserGroupType UserGroupType { get; set; }

        public decimal CurrentPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
