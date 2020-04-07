namespace Application.Courses.Queries.GetPaginatedCourse
{
    public class PaginatedCourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public long gradeid { get; set; }
        public string gradename { get; set; }
        public bool istrial { get; set; }
    }
}