using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class UserRole : AuditableEntity
    {
        public long UserId { get; set; }
        public long RoleId { set; get; }
    }
}
