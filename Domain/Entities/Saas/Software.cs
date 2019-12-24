using Bridge.Domain.Enums;

namespace Bridge.Domain.Entities.Saas
{
    public class Software
    {
        public int SoftwareId { get; set; }
        public SoftwareNames SoftwareName { get; set; }
        public string Details { get; set; }
        public string AccessLink { get; set; }
    }
}
