using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class QuizSummary : AuditableEntity
    {
        public long StudentId { get; set; }
        public long QuizId { get; set; }
        public int QSummary { get; set; }
        public int Attempts { get; set; }
    }
}
