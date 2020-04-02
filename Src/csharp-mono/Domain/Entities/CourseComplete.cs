namespace Bridge.Domain.Entities
{
    public class CourseComplete //: EntityBase, ICourseComplete
    {
        Course Course { get; set; }
        Chapter[] Chapters { get; set; }
    }
}
