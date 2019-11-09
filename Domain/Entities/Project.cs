using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool MultiContractor { get; set; }
    }
}