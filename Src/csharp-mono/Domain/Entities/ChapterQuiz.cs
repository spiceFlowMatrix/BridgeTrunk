using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class ChapterQuiz : AuditableEntity
    {
        public long QuizId { get; set; }
        public long ChapterId { get; set; }
        public int ItemOrder { get; set; }
    }
}
