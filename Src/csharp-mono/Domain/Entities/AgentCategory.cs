using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class AgentCategory : EntityBase
    {
        public string CategoryName { get; set; }
        public int Commission { get; set; }
    }
}
