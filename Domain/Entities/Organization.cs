using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool Public { get; set; }
    }
}