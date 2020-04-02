using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class PurchagePdf : EntityBase
    {
        public string PurchageId { get; set; }
        public long PdfFile { get; set; }
    }

    public class PurchageUpload : EntityBase
    {
        public string PurchageId { get; set; }
        public long PdfFile { get; set; }
    }

}
