﻿using System;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class Files : AuditableEntity
    {        
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public long FileSize { get; set; }
        public long FileTypeId { get; set; }
        public int TotalPages { get; set; }
        public string Duration { get; set; }
    }
}
