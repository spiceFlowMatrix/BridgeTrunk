using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Subscriptions : AuditableEntity
    {
        public string UserId { get; set; }
        public long SubscriptionMetadataId { get; set; }        
    }
}
