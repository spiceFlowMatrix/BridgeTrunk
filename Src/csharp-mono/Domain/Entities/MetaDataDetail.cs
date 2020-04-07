using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class MetaDataDetail : AuditableEntity
    {
        public long MetadataId { get; set; }
        public long DetailId { get; set; }
        public int DetailTypeId { get; set; }
    }
}
