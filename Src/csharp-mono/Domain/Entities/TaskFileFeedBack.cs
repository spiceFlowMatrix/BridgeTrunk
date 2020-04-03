using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class TaskFileFeedBack : AuditableEntity 
    {
        public long TaskId { get; set; }
        public long FileId { get; set; }
    }
}
