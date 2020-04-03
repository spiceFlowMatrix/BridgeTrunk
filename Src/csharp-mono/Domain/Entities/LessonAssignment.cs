using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class LessonAssignment : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public long LessonId { get; set; }
    }
}
