using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class Subscriptions : EntityBase
    {
        public string UserId { get; set; }
        public long SubscriptionMetadataId { get; set; }        
    }
}
