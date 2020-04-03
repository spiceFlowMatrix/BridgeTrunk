using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class TermsAndConditions : AuditableEntity
    {
        public string Terms { get; set; }
    }
}
