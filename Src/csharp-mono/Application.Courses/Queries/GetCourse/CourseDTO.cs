using Domain.Enums;

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
        public Culture Culture { get; set; }
        public long TeacherId { get; set; }
        public string CultureName { get; set; }
        public string StatusName { get; set; }
        public string TeacherName { get; set; }
    }
}