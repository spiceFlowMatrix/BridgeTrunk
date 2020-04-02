using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class DiscussionTopicLikes : EntityBase
    {
        public long TopicId { get; set; }
        public long UserId { get; set; }
        public bool Like { get; set; }
        public bool DisLike { get; set; }
    }
}
