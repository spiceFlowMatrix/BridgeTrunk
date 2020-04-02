using System;

namespace Bridge.Domain.Entities
{
    public class StudentChapterProgress : EntityBase
    {
        public long ChapterId { get; set; }
        public long ChapterStatus { get; set; }
        public long StudentId { get; set; }
    }
}
