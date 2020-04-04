using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Bridge.Domain.Entities
{
    public class UpdateStudentCourseProgress
    {
        public long ID { get; set; }

        public StudentCourseProgress objStudentCourseProgress { get; set; }
    }
}
