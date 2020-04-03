using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Bridge.Application.Models
{
    public class ApiResponse
    {
        public int ReturnCode { get; set; }
        public int response_code { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public object data { get; set; }
        public int? totalcount { get; set; }
    }
}