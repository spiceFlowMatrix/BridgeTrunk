using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class NotificationLog : EntityBase
    {
        public long NotifiedUserId { get; set; }
        public long LogObjectId { get; set; }
        public bool IsRead { get; set; }
    }
}
