using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class LessonAssignmentSubmissionFile : AuditableEntity
    {
        public long SubmissionId { get; set; }
        public long FileId { get; set; }
    }
}
