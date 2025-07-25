﻿using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Currency : AuditableEntity
    {
        public string currency { get; set; }
        public string abbreviation { get; set; }
        public string symbol { get; set; }
    }
}
