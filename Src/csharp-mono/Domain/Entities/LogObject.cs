using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class LogObject : AuditableEntity
    {
        public long TypeId { get; set; }
        public long EntityKey { get; set; }
        public long ActionUserId { get; set; }
        public string TimeStamp { get; set; }
    }
}
