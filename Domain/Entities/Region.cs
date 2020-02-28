using System.Collections.Generic;

namespace Bridge.Domain.Entities
{
    public class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public string RegionId { get; set; }
        public string RegionDescription { get; set; }

        public ICollection<Territory> Territories { get; private set; }
    }
}
