using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class LogObjectTypes : EntityBase
    {
        public string EntityType { get; set; }
        public string Action { get; set; }
    }
}
