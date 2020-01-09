using Bridge.Domain.Common;
using System;

namespace Bridge.Domain.Entities.Saas
{
    public class PlanHistory : AuditableEntity
    {
        public string SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public string PlanId { get; set; }
        public Plan Plan { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
