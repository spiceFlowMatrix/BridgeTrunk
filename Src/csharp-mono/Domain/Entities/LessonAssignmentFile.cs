using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class LessonAssignmentFile : AuditableEntity
    {
        public long AssignmentId { get; set; }
        public long FileId { get; set; }
    }
}
