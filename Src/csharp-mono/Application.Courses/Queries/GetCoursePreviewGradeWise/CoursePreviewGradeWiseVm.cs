using System.Collections.Generic;

namespace Application.Courses.Queries.GetCoursePreviewGradeWise
{
    public class CoursePreviewGradeWiseVm
    {
        public long id { get; set; }
        public string name { get; set; }

        public List<GradeWiseCoursePriviewModel> courses { get; set; }
    }

    public class GradeWiseCoursePriviewModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
    }
      public class CoursePriviewGradeWiseModel
    {
        public long id { get; set; }
        public string name { get; set; }

        public List<GradeWiseCoursePriviewModel> courses { get; set; }
    }
}