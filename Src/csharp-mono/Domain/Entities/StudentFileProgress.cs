using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Domain.Entities
{
    public class StudentFileProgress : EntityBase
    {
        public long FileId { get; set; }
        public long StudentId { get; set; }
        public decimal FileProgress { get; set; }
    }
}
