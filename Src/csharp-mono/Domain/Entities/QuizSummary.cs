using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class QuizSummary : EntityBase
    {
        public long StudentId { get; set; }
        public long QuizId { get; set; }
        public int QSummary { get; set; }
        public int Attempts { get; set; }
    }
}
