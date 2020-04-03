using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class LessonFile : AuditableEntity
    {
        public long LessionId { get; set; }
        public long FileId { get; set; }
    }
}
