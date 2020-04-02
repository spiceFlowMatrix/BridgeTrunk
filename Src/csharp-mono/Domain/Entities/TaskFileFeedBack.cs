using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class TaskFileFeedBack : EntityBase 
    {
        public long TaskId { get; set; }
        public long FileId { get; set; }
    }
}
