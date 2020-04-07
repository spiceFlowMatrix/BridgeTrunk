using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Contact : AuditableEntity
    {
        public string FirstName { get; set; }
        public string Email { get; set; }        
        public string CountryCode { get; set; }
        public string Phone { get; set; }
    }
}
