﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bridge.Domain.Entities
{
    public class StudentLessonComplete
    {
        public Lesson Lesson { get; set; }
        public PdfFile PdfFile { get; set; }
        public Quiz Quiz { get; set; }
        public StudentLessonProgress StudentProgress { get; set; }
    }
}
