using System;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Question : AuditableEntity
    {
        public long QuestionTypeId { get; set; }

		public string QuestionText { get; set; }

        public string Explanation { get; set; }
        public bool IsMultiAnswer { get; set; } = false;

        // [ForeignKey("QuestionTypeId")]
        public QuestionType QuestionType { get; set; }
    }
}
