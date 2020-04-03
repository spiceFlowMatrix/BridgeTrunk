using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class FeedBackStaff : AuditableEntity
    {
        public long FeedBackId { get; set; }
        public long UserId { get; set; }
        public long Type { get; set; }
        public bool IsManager { get; set; }
    }
}
