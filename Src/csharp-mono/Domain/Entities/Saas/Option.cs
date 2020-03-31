using Bridge.Domain.Common;
using Bridge.Domain.Enums.Saas;

namespace Bridge.Domain.Entities.Saas
{
    public class Option : AuditableEntity
    {
        public EOptionName OptionName { get; set; }
    }
}
