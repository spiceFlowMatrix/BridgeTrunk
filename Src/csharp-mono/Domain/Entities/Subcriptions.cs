using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Subcriptions : AuditableEntity
    {
        public string Name { get; set; }
    }
}
