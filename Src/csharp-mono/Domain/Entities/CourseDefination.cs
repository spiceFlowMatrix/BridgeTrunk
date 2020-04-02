using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class CourseDefination : EntityBase
    {
        public long GradeId { get; set; }
        public long CourseId { get; set; }
        public string Subject { get; set; }
        public string BasePrice { get; set; }
    }
}
