using System;
using System.Collections.Generic;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Quiz : AuditableEntity
    {
        public Quiz()
        {
            NumQuestions = 4;
            PassMark = 50;
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public int NumQuestions { get; set; }

        public override string ToString()
        {
            return Code + ":" + Name;
        }

        public Decimal PassMark { get; set; }

        public int TimeOut { get; set; }

        public int ItemOrder { get; set; }
    }
}