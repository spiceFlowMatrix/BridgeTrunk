using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class PackageCourse : EntityBase
    {
        public long PackageId { get; set; }
        public long CourseId { get; set; }
    }
}
