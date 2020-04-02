using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class QuizProgress : EntityBase
    {
        public long ChapterId { get; set; }
        public long QuizId { get; set; }
        public long UserId { get; set; }
        public long Progress { get; set; }
    }
}
