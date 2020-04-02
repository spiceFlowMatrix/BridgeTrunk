using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bridge.Domain.Entities
{
    public class Question : EntityBase
    {
        public long QuestionTypeId { get; set; }

        [Required]
        [StringLength(255)]
		public string QuestionText { get; set; }

        [StringLength(255)]
        public string Explanation { get; set; }
        public bool IsMultiAnswer { get; set; } = false;

        [ForeignKey("QuestionTypeId")]
        public QuestionType QuestionType { get; set; }
    }
}
