using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Domain.Entities
{
    public class AssignmentFile : EntityBase
    {
        public long AssignmentId { get; set; }
        public long FileId { get; set; }
    }
}
