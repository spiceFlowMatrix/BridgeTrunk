namespace Bridge.Domain.Entities
{
    public class Chapter : EntityBase
    {        
        public string Name { get; set; }
        public string Code { get; set; }
        public long CourseId { get; set; }
        public long? QuizId { get; set; }
        public int ItemOrder { get; set; }
    }
}
