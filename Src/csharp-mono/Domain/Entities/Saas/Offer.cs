using Bridge.Domain.Common;
using System;

namespace Bridge.Domain.Entities.Saas
{
    public class Offer : AuditableEntity
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Description { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public int DurationMonths { get; set; }
        public DateTime DurationEndDate { get; set; }
    }
}
