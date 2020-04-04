using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class QuestionAnswer : AuditableEntity
    {
        public string Answer { get; set; }
        public string ExtraText { get; set; }
        public bool IsCorrect { get; set; }
        public long QuestionId { get; set; }
        //public long FileId { get; set; }

       // [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
