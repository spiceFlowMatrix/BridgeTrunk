using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Logs : AuditableEntity
    {
        public string Data { get; set; }
        public string TestColumn { get; set; }
        
    }
}
