namespace Bridge.Domain.Entities
{
    public class GroupCourse //: AuditableEntity, IGroupCourse
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public long CourseId { get; set; }
    }
}
