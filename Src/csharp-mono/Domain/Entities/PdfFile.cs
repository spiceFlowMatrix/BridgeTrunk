namespace Bridge.Domain.Entities
{
    public class PdfFile //: EntityBase, IPdfFile
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }

}
