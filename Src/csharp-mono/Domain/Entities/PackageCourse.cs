using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class PackageCourse : AuditableEntity
    {
        public long PackageId { get; set; }
        public long CourseId { get; set; }
    }
}
