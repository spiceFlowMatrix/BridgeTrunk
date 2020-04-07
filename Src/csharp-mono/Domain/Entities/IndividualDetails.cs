using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class IndividualDetails : AuditableEntity
    {
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string SchoolName { get; set; }
        public string FatherNumber { get; set; }
        public string IdCardNumber { get; set; }
        public string PermanentAddress { get; set; }
        public string Village { get; set; }
        public string ProvinceId { get; set; }
        public string CityId { get; set; }
        public string Phone { get; set; }
        public string CountryId { get; set; }
        public string RefferedBy { get; set; }
        public string Email { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public string SexId { get; set; }
        public string DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string CurrentAddress { get; set; }
        public string MaritalStatusId { get; set; }
        public string Remarks { get; set; }
        public string StudentTazkira { get; set; }
        public string ParentTazrika { get; set; }
        public string PreviousMarksheets { get; set; }
        public long? GradeId { get; set; }
        public string SoicalMediaLinked { get; set; }
        public string SocialMediaAccount { get; set; }
        public long? UserId { get; set; }
    }
}
