using System;

namespace Bridge.Domain.Entities
{
    public class Teacher //: AuditableEntity, ITeacher
    {

        public long Id { get; set; }
        public string Bio { get; set; }
        public string PhotoUrl { get; set; }
        public string Designation { get; set; }
        public string FullName { get; set; }

        public Teacher()
        {
        }
    }
}
