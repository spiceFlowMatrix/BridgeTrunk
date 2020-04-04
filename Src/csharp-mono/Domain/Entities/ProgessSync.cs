using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class ProgessSync : AuditableEntity
    {
        //public long Id { get; set; }
        public long? GradeId { get; set; }
        public bool IsStatus { get; set; }
        public long? LessonProgressId { get; set; }
        public long? LessonId { get; set; }
        public decimal? LessonProgress { get; set; }
        public long? QuizId { get; set; }
        public long? TotalRecords { get; set; }
        public long UserId { get; set; }
        public long FileId { get; set; }
    }

    public class SyncData
    {
        public List<ProgessSync> progressdata { get; set; }
        public List<QuizTimerSync> timerdata { get; set; }
    }
}
