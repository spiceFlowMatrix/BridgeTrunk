using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Domain.Entities
{
    public class LessonFile : EntityBase
    {
        public long LessionId { get; set; }
        public long FileId { get; set; }
    }
}
