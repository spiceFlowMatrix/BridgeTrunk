using Bridge.Domain.Common;
using Domain.Enums;

namespace Bridge.Domain.Entities
{
    public class DocumentFileDetail: AuditableEntity
    {
        public EntityType EntityType { get; set; }
        public long EntityRecordId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RawFileMimeType { get; set; }
        public long RawFileSizeBytes { get; set; }
        public string StorageDirectoryPath { get; set; }
        public ContentType ContentType { get; set; }
    }
}