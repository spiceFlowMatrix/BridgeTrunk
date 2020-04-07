using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class DefaultValues : AuditableEntity
    {
        public int timeout { get; set; }
        public int reminder { get; set; }
        public int intervals { get; set; }
        public bool istimeouton { get; set; }
    }
}
