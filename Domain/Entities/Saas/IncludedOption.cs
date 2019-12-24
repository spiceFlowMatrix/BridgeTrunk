using Bridge.Domain.Common;
using System;

namespace Bridge.Domain.Entities.Saas
{
    public class IncludedOption : AuditableEntity
    {
        public int Id { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }

        public int OptionId { get; set; }
        public Option Option { get; set; }

        public DateTime RemovedDate { get; set; }
    }
}
