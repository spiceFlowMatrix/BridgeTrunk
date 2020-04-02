using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class DiscussionComments : EntityBase
    {
        public string Comment { get; set; }
        public long TopicId { get; set; }
    }
}
