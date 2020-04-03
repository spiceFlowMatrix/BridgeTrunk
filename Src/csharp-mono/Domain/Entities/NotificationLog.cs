using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class NotificationLog : AuditableEntity
    {
        public long NotifiedUserId { get; set; }
        public long LogObjectId { get; set; }
        public bool IsRead { get; set; }
    }
}
