using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class StudParent : AuditableEntity
    {
        public long StudentId { get; set; }
        public long ParentId { get; set; }
    }
}
