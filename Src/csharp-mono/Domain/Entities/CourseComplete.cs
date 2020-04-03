namespace Bridge.Domain.Entities
{
    public class CourseComplete //: AuditableEntity, ICourseComplete
    {
        Course Course { get; set; }
        Chapter[] Chapters { get; set; }
    }
}
