﻿using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class OrderDetail : AuditableEntity
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
