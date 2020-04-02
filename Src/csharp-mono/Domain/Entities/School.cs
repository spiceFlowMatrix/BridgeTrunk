using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class School : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
