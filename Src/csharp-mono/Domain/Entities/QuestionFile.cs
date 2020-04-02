using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Domain.Entities
{
    public class QuestionFile : EntityBase
    {
        public long QuestionId { get; set; }
        public long FileId { get; set; }
    }
}
