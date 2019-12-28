using Bridge.Domain.Common;

namespace Bridge.Domain.Entities.Saas
{
    public class OfferInclude : AuditableEntity
    {
        public string OfferId { get; set; }
        public Offer Offer { get; set; }

        public string PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
