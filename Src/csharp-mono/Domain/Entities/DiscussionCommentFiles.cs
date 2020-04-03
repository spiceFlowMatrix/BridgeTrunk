using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class DiscussionCommentFiles : AuditableEntity
    {
        public string Name { get; set; }
        public long? CommentId { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public long FileSize { get; set; }
        public long FileTypeId { get; set; }
        public int TotalPages { get; set; }
        public string Duration { get; set; }
    }
}
