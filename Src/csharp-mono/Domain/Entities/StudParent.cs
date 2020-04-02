using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class StudParent : EntityBase
    {
        public long StudentId { get; set; }
        public long ParentId { get; set; }
    }
}
