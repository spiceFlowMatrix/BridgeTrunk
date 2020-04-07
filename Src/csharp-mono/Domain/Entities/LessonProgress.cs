using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class LessonProgress :EntityBase
    {
        public long ChapterId { get; set; }
        public long LessonId { get; set; }
        public long UserId { get; set; }
        public long Progress { get; set; }
    }
}
