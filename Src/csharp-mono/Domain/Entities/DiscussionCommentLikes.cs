using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class DiscussionCommentLikes : AuditableEntity
    {
        public long CommentId { get; set; }
        public long UserId { get; set; }
        public bool Like { get; set; }
        public bool DisLike { get; set; }
    }
}
