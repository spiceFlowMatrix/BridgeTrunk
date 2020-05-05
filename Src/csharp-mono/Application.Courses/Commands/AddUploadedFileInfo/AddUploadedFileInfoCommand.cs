using Domain.Enums;
using MediatR;

namespace Application.Courses.Commands.AddUploadedFileInfo
{
    public class AddUploadedFileInfoCommand: IRequest<object>
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