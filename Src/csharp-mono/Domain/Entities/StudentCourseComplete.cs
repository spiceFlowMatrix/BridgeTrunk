﻿using System;
using System.Collections.Generic;


namespace Bridge.Domain.Entities
{
    public class StudentCourseComplete
    {
		public Course Course { get; set; }
		public List<StudentChapterComplete> Chapters { get; set; }
		public StudentCourseProgress StudentProgress { get; set; }
    }
}
