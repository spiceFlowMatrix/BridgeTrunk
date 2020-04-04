using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class QuizTimerSync : AuditableEntity
    {     
        public bool isStatus { get; set; }
        public string passingScore { get; set; }
        public long quizId { get; set; }
        public string quizTime { get; set; }
        public long userId { get; set; }
        public string yourScore { get; set; }
    }
}