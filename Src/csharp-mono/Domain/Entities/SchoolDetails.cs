using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class SchoolDetails : AuditableEntity
    {
        public string RegisterNumber { get; set; }
        public string SchoolTypeId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string SectionTypeId { get; set; }
        public int NumberOfTeacherMale { get; set; }
        public int NumberOfTeacherFemale { get; set; }
        public int NumberOfStudentMale { get; set; }
        public int NumberOfStudentFemale { get; set; }
        public int NumberOfStaffMale { get; set; }
        public int NumberOfStaffFemale { get; set; }
        public string PowerAddressId { get; set; }
        public string InternetAccessId { get; set; }
        public string BuildingOwnershipId { get; set; }
        public string Computers { get; set; }
        public string Monitors { get; set; }
        public string Routers { get; set; }
        public string Dongles { get; set; }
        public string SchoolLicense { get; set; }
        public string RegisterationPaper { get; set; }
    }


}