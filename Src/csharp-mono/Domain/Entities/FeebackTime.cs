using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Domain.Entities
{
    public class FeebackTime : EntityBase
    {
        public long FeedbackId { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
    }
}
