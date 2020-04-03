using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class DiscussionTopic : AuditableEntity
    {
        public long CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsPublic { get; set; }
    }
}
