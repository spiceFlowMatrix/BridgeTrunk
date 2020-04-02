using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class LessonAssignmentSubmissionFile : EntityBase
    {
        public long SubmissionId { get; set; }
        public long FileId { get; set; }
    }
}
