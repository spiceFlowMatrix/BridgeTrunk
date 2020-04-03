using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class AddtionalServices : AuditableEntity
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
