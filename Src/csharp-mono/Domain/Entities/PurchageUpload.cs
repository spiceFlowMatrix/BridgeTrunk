using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class PurchageUpload : AuditableEntity
    {
        public string PurchageId { get; set; }
        public long PdfFile { get; set; }
    }
}