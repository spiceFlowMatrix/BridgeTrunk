﻿using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class UserNotifications : AuditableEntity
    {
        public string Tag { get; set; }
        public int Type { get; set; }
        public long UserId { get; set; }
        public bool IsRead { get; set; }
        public long? CourseId { get; set; }
        public long? AssignmentId { get; set; }
        public long? LessionId { get; set; }
        public long? DiscussionId { get; set; }
        public long? CommentId { get; set; }
        public long? ChapterId { get; set; }
        public long? QuizId { get; set; }
        public long? FileId { get; set; }
    }
}
