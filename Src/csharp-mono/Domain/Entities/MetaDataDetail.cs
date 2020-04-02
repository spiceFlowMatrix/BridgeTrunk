using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class MetaDataDetail : EntityBase
    {
        public long MetadataId { get; set; }
        public long DetailId { get; set; }
        public int DetailTypeId { get; set; }
    }
}
