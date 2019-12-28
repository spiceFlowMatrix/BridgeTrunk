using Bridge.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities.Saas
{
    class PlanHistory : AuditableEntity
    {
        public string SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public string PlanId { get; set; }
        public Plan Plan { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
