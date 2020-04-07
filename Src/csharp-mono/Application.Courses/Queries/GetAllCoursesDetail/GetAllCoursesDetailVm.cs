using System.Collections.Generic;

namespace Application.Courses.Queries.GetAllCoursesDetail
{
    public class GetAllCoursesDetailVm
    {
        public List<CourseDetailModel> courses { get; set; }
        public List<LessonDetailModel> lessons { get; set; }
        public List<AssignmentDetails> assignment { get; set; }
    }
    public class CourseDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<ResponseGradeModel> GradeDetails { get; set; }

    }
    public class ResponseGradeModel
    {
        public long id { get; set; }
        public string name { set; get; }
        public string description { set; get; }
    }
    public class LessonDetailModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public string coursename { get; set; }
        public long chapterid { get; set; }
        public long courseid { get; set; }
        public long lessonfileid { get; set; }
        public string lessonfilename { get; set; }
        public long filetypeid { get; set; }
        public string filetypename { get; set; }
        public decimal progressval { get; set; }
        public long lessonquizid { get; set; }
    }
    public class AssignmentDetails
    {
        public long id { get; set; }
        public string name { get; set; }
        public CourseDetailModel coursewithgrade { get; set; }

    }

    public class ResponseFilesModel
    {
        public long Id { get; set; }
        public string name { get; set; }
        public long filetypeid { get; set; }
        public string filetypename { get; set; }
    }

     public class ResponseStudentLessonProgressModel
    {
        public long id { get; set; }
        public long lessonid { get; set; }
        public long lessonstatus { get; set; }
        public long studentid { get; set; }
        public decimal lessonprogress { get; set; }
        public long duration { get; set; }
    }
}