using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class DiscussionComments : AuditableEntity
    {
        public string Comment { get; set; }
        public long TopicId { get; set; }
    }
}
