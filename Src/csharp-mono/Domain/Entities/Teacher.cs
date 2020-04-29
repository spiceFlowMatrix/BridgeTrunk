using System;

namespace Bridge.Domain.Entities
{
    public class Teacher
    {

        public long Id { get; set; }
        public string Bio { get; set; }
        public string PhotoUrl { get; set; }
        public string Designation { get; set; }
        public string FullName { get; set; }
        public Course Course { get; set; }

        public Teacher()
        {
        }
    }
}
