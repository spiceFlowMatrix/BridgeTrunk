using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class School : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
