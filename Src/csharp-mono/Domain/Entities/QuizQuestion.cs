using System;
using System.Collections.Generic;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class QuizQuestion : AuditableEntity
    {
        public long QuizId { get; set; }
        public long QuestionId { get; set; }

        // [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
        // [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}