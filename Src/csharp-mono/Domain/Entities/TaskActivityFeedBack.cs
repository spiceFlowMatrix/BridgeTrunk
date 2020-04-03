using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class TaskActivityFeedBack : AuditableEntity
    {
        public long TaskId { get; set; }
        public long UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
