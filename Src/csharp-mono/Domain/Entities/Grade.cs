namespace Bridge.Domain.Entities
{
    public class Grade : EntityBase
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public long SchoolId { get; set; }
    }
}