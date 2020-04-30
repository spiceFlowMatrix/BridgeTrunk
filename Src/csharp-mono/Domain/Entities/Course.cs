using System.Collections.Generic;
using System.ComponentModel;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Course : AuditableEntity
    {        
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Culture {get; set;}
        public long TeacherId {get; set;}
        public string Image { get; set; }        
        public decimal? PassMark { get; set; }
        public int Status { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<CourseRevision> Revisions { get; set; }
    }
}
