using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class FeebackTime : AuditableEntity
    {
        public long FeedbackId { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
    }
}
