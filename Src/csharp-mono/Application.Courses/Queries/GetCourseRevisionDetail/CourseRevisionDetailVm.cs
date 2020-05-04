namespace Application.Courses.Queries.GetCourseRevisionDetail {
    public class CourseRevisionDetailVm {
        public RevisionDetail RevisionDetails { get; set; }
        public CourseDetail CourseDetails { get; set; }
        public StudentAppMetaData StudentAppMetaData { get; set; }
        public ContentSummary ContentSummary { get; set; }

    }

    public class CourseDetail {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Culture { get; set; }
        public string TeacherName { get; set; }
    }

    public class RevisionDetail {
        public long RevisionId { get; set; }
        public string RevisionName { get; set; }
        public string Summary { get; set; }
        public string AdministeredOn { get; set; }
        public string AdministeredBy { get; set; }
        public string PublishedOn { get; set; }
        public string PublishedBy { get; set; }
        public string ReleasedOn { get; set; }
        public string ReleasedBy { get; set; }
    }

    public class StudentAppMetaData {
        public string test { get; set; }
    }

    public class ContentSummary {
        public string test { get; set; }
    }

}