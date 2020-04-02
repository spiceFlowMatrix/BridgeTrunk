using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class Package : EntityBase
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
