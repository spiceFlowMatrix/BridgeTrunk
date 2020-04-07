namespace Application.Courses.Queries.GetCourseDefinition
{
    public class CourseDefinitionVm
    {
        public long Id { get; set; }
        public long GradeId { get; set; }
        public string GradeName { get; set; }
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public string Subject { get; set; }
        public string BasePrice { get; set; }
    }
}