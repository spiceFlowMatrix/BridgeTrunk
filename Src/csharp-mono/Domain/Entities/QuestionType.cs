using System;
using System.ComponentModel.DataAnnotations;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class QuestionType : AuditableEntity
    {

        [Required]
        [StringLength(6)]
        public string Code { get; set; }

    }
}
