using System;
using System.ComponentModel.DataAnnotations;

namespace Bridge.Domain.Entities
{
    public class QuestionType : EntityBase
    {

        [Required]
        [StringLength(6)]
        public string Code { get; set; }

    }
}
