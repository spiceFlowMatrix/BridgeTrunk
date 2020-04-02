using System;

namespace Bridge.Domain.Entities
{
    public class UserCourse : EntityBase
    {        
        public long UserId { get; set; }
        public long CourseId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool? IsExpire { get; set; }
    }
}
