namespace Application.Courses.Queries.GetCourseListByGradeId
{
    public class CourseListByGradeIdVm
    {
        public long id { get; set; }
        public long gradeid { get; set; }
        public long courseid { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }
}