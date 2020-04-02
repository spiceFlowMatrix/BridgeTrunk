using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Domain.Entities
{
    public class FeedbackFile : EntityBase
    {
        public long FeedtimeId { get; set; }
        public long FileId { get; set; }
    }
}
