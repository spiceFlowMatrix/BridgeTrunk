namespace Application.Courses.Commands.DeleteCourseDefination
{
    public class DeleteCourseDefinationVm
    {
        public long Id { get; set; }
        public long GradeId { get; set; }
        public long CourseId { get; set; }
        public string Subject { get; set; }
        public string BasePrice { get; set; }
    }
}