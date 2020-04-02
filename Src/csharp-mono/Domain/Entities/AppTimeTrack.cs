using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class AppTimeTrack : EntityBase
    {
        public long UserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ServiceProvider { get; set; }
        public string School { get; set; }
        public string SubjectsTaken { get; set; }
        public string Grade { get; set; }
        public string HardwarePlatform { get; set; }
        public string OperatingSystem { get; set; }
        public string Version { get; set; }
        public string Isp { get; set; }
        public string ActivityTime { get; set; }
        public string Outtime { get; set; }
        public string NetworkSpeed { get; set; }
    }
}
