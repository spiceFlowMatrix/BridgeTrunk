using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Domain.Entities
{
    public class UserRole : EntityBase
    {
        public long UserId { get; set; }
        public long RoleId { set; get; }
    }
}
