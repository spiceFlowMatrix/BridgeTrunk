using System;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class StudentChapterProgress : AuditableEntity
    {
        public long ChapterId { get; set; }
        public long ChapterStatus { get; set; }
        public long StudentId { get; set; }
    }
}
