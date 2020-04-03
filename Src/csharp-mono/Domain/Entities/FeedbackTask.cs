using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class FeedBackTask : AuditableEntity
    {
        public long FeedbackId { get; set; }        
        public string Description { get; set; }
        public string FileLink { get; set; }
        public long Type { get; set; }
        //public int Status { get; set; }
    }

    public class FeedBackTaskStatus : AuditableEntity
    {
        public long FeedbackId { get; set; }
        public long Status { get; set; }
    }

    public class FeedBackTaskStatusOption : AuditableEntity
    {        
        public string Name { get; set; }
    }
}
