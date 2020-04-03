using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class FileProgress : AuditableEntity
    {
        public long LessonId { get; set; }
        public long FileId { get; set; }
        public long UserId { get; set; }
        public long Progress { get; set; }
    }
}
