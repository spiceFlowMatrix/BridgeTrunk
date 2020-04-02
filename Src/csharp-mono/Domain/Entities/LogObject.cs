using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class LogObject : EntityBase
    {
        public long TypeId { get; set; }
        public long EntityKey { get; set; }
        public long ActionUserId { get; set; }
        public string TimeStamp { get; set; }
    }
}
