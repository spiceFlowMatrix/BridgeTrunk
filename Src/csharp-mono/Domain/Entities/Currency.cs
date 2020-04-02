using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class Currency : EntityBase
    {
        public string currency { get; set; }
        public string abbreviation { get; set; }
        public string symbol { get; set; }
    }
}
