using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class ChapterProgress : AuditableEntity
    {
        public long CourseId { get; set; }
        public long ChapterId { get; set; }
        public long UserId { get; set; }
        public long Progress { get; set; }
    }
}
