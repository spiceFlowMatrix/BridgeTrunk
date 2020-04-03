using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class AgentCategory : AuditableEntity
    {
        public string CategoryName { get; set; }
        public int Commission { get; set; }
    }
}
