using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public  class Discount : EntityBase
    {
        public string PackageName { get; set; }
        public int OffTotalPrice { get; set; }
        public int OffSubscriptions { get; set; }
        public int FreeSubscriptions { get; set; }
    }
}
