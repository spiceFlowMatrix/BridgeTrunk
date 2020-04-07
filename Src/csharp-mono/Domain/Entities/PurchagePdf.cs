using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class PurchagePdf : AuditableEntity
    {
        public string PurchageId { get; set; }
        public long PdfFile { get; set; }
    }

}
