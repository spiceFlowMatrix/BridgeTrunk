using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class CourseGrade : AuditableEntity
    {
        public long CourseId { get; set; }
        public long Gradeid { get; set; }
    }
}
