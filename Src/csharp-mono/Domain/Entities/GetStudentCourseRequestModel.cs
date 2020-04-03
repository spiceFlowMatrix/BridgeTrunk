namespace Bridge.Domain.Entities
{
    public class GetBundleCourseRequestModel// : AuditableEntity, IGetBundleCourseRequestModel
    {
        public long StudentId { get; set; }
        public long CourseId { get; set; }
    }
}
