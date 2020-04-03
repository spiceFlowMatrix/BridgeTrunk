using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Chapter : AuditableEntity
    {        
        public string Name { get; set; }
        public string Code { get; set; }
        public long CourseId { get; set; }
        public long? QuizId { get; set; }
        public int ItemOrder { get; set; }
    }
}
