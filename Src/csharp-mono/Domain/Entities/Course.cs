using System.ComponentModel;

namespace Bridge.Domain.Entities
{
    public class Course : EntityBase
    {        
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }        
        public decimal? PassMark { get; set; }
        public bool istrial { get; set; }
    }
}
