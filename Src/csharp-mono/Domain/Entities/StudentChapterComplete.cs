using System;
using System.Collections.Generic;

namespace Bridge.Domain.Entities
{
    public class StudentChapterComplete
    {
		public Chapter Chapter { get; set;}
		public List<StudentLessonComplete> Lessons { get; set; }
		public StudentChapterProgress StudentProgress { get; set; }
    }
}
