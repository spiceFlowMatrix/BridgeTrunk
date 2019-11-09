using System;
using Bridge.Domain.Entities;

namespace Bridge.Domain.Common
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public string LastModifiedByUserId { get; set; }
        public User LastModifiedByUser { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
    }
}