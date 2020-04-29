namespace Application.Courses.Queries.GetCourse
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public int? CultureId { get; set; }
        public long? TeacherId { get; set; }
        public long gradeid { get; set; }
        public string gradename { get; set; }
        public bool istrial { get; set; }
    }
}