using Bridge.Domain.Common;
using System;

namespace Bridge.Domain.Entities.Saas
{
    public class Invoice : AuditableEntity
    {
        public string CustomerInvoiceData { get; set; }

        public string SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public string PlanHistoryId { get; set; }
        public PlanHistory PlanHistory { get; set; }

        public DateTime InvoicePeriodStartDate { get; set; }
        public DateTime InvoicePeriodEndDate { get; set; }

        public string InvoiceDescription { get; set; }
        public decimal InvoiceAmount { get; set; }
        public DateTime InvoiceDueOn { get; set; }
        public DateTime InvoicePaidOn { get; set; }
    }
}
