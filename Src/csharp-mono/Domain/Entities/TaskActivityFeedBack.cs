using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class TaskActivityFeedBack : EntityBase
    {
        public long TaskId { get; set; }
        public long UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
