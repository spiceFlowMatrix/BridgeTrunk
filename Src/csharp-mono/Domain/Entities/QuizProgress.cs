using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class QuizProgress : AuditableEntity
    {
        public long ChapterId { get; set; }
        public long QuizId { get; set; }
        public long UserId { get; set; }
        public long Progress { get; set; }
    }
}
