using Bridge.Domain.Common;
using System;

namespace Bridge.Domain.Entities.Saas
{
    public class IncludedOption : AuditableEntity
    {
        public string PlanId { get; set; }
        public Plan Plan { get; set; }

        public string OptionId { get; set; }
        public Option Option { get; set; }

        public DateTime RemovedDate { get; set; }
    }
}
