using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class ERPAccounts : EntityBase 
    {
        public int Type { get; set; }
        public string AccountCode { get; set; }
    }
}
