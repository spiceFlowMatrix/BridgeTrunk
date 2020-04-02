using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Domain.Entities
{
    public class AssignmentStudent : EntityBase
    {
        public long AssignmentId { get; set; }
        public long StudentId { get; set; }
        public bool IsApproved { get; set; }
        //public long TeacherId { get; set; }
    }
}
