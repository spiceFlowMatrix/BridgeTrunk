using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Lesson : AuditableEntity
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public long? ChapterId { get; set; }
        public int? ItemOrder { get; set; }
        public int LessonType { get; set; }
        public int? Status { get; set; }
        public Chapter Chapter { get; set; }
    }
}
