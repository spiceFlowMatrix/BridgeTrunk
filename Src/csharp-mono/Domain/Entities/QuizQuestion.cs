using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bridge.Domain.Entities
{
    public class QuizQuestion : EntityBase
    {
        [Required]
        public long QuizId { get; set; }
        [Required]
        public long QuestionId { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}