using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Domain.Entities
{
    public class CourseGrade : EntityBase
    {
        public long CourseId { get; set; }
        public long Gradeid { get; set; }
    }
}
