using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class LessonAssignmentFile : EntityBase
    {
        public long AssignmentId { get; set; }
        public long FileId { get; set; }
    }
}
