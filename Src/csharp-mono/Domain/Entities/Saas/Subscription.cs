using Bridge.Domain.Common;
using System;

namespace Bridge.Domain.Entities.Saas
{
    public class Subscription : AuditableEntity
    {
        public string UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }

        public DateTime TrialPeriodStartDate { get; set; }
        public DateTime TrialPeriodEndDate { get; set; }

        public bool SubscribeAfterTrial { get; set; }

        public string CurrentPlanId { get; set; }
        public Plan CurrentPlan { get; set; }

        public string OfferId { get; set; }
        public Offer Offer { get; set; }

        public DateTime OfferStartDate { get; set; }
        public DateTime OfferEndDate { get; set; }

        public DateTime DateSubscribed { get; set; }

        public DateTime ValidTo { get; set; }

        public DateTime DateUnsubscribed { get; set; }
    }
}
