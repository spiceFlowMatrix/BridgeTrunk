﻿using Bridge.Domain.Common;
using System.Collections.Generic;

namespace Bridge.Domain.Entities
{
    public class Customer : AuditableEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public ICollection<Order> Orders { get; private set; }
    }
}
