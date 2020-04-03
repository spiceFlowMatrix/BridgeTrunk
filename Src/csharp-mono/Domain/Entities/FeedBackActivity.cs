using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class FeedBackActivity : AuditableEntity
    {
        public long FeedbackId { get; set; }
        public long FeedbackTaskId { get; set; }
        public long UserId { get; set; }
        public long Type { get; set; }
    }
}
