using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class UserSessions : AuditableEntity
    {
        public long UserId { get; set; }
        public string AccessToken { get; set; }
        public string DeviceToken { get; set; }
        public string DeviceType { get; set; }
        public string Version { get; set; }
    }
}
