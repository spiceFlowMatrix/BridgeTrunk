using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Assignment : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public long ChapterId { get; set; }
        public int ItemOrder { get; set; }
    }
}
