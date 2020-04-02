using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Domain.Entities
{
    public class CourseItemProgressSync : EntityBase
    {
        public long Userid { get; set; }
        public long Lessonid { get; set; }
        public long Lessonprogress { get; set; }
        public long Quizid { get; set; }
        public long IsStatus { get; set; }
    }
}
