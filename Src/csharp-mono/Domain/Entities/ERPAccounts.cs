using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class ERPAccounts : AuditableEntity 
    {
        public int Type { get; set; }
        public string AccountCode { get; set; }
    }
}
