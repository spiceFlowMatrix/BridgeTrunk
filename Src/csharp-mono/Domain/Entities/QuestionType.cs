using System;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class QuestionType : AuditableEntity
    {
        public string Code { get; set; }

    }
}
