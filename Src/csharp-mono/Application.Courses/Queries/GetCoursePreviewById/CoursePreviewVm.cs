using System.Collections.Generic;

namespace Application.Courses.Queries.GetCoursePreviewById
{
    public class CoursePreviewVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        //public string CreationTime { get; set; }

        public List<ChapterPreviewModel> chapters { get; set; }
    }
        public class ChapterPreviewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int itemorder { get; set; }
        public List<object> lessons { get; set; }

        public List<QuizPreviewModel> quizs { get; set; }
        public List<AssignmentPreviewModel> assignments { get; set; }
    }
        public class QuizPreviewModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int numquestions { get; set; }
        public  int itemorder { get; set; }
        public int type { get; set; }
    }
    public class AssignmentPreviewModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int itemorder { get; set; }
        public int type { get; set; }
        public List<ResponseAssignmentFileModel> assignmentfiles { get; set; }
    }
        public class ResponseAssignmentFileModel
    {
        public long id { get; set; }
        public ResponseFilesModel files { get; set; }
    }
        public class ResponseFilesModel
    {
        public long Id { get; set; }
        public string name { get; set; }
        public string filename { get; set; }
        public string description { get; set; }
        public string filetypename { get; set; }
        public string url { get; set; }
        public long filesize { get; set; }
        public long filetypeid { get; set; }
        public int totalpages { get; set; }
        public string duration { get; set; }
    }
        public class LessonPreviewModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int? itemorder { get; set; }
        public int type { get; set; }
        public List<ResponseLessonFileModel> lessonfiles { get; set; }
        public ResponseLessionAssignmentDTO assignment { get; set; }

    }
     public class ResponseLessonFileModel
    {
        public long  id { get; set; }                     
        public ResponseFilesModel files { get; set; }
        public ResponseStudentLessonProgressModel progress { get; set; }
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
      public class ResponseLessionAssignmentDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public List<ResponseLessonAssignmentFileDTO> assignmentfiles { get; set; }
    }
        public class ResponseLessonAssignmentFileDTO
    {
        public long id { get; set; }
        public ResponseFilesModel files { get; set; }
        public ResponseStudentLessonProgressModel progress { get; set; }
    }
}