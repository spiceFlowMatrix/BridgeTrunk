using Bridge.Domain.Common;
using Bridge.Domain.Enums.Saas;

namespace Bridge.Domain.Entities.Saas
{
    public class Software : AuditableEntity
    {
        public ESoftwareName SoftwareName { get; set; }
        public string Details { get; set; }
        public string AccessLink { get; set; }
    }
}
