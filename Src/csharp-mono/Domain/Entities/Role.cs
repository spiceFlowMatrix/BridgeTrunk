using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Role : AuditableEntity
    {        
        public string Name { get; set; }
        public string RoleKey { get; set; }
    }
}
