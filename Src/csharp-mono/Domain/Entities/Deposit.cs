using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class Deposit : EntityBase
    {
        public string DepositDate { get; set; }
        public decimal DepositAmount { get; set; }
        public long SalesAgentId { get; set; }
        public string DocumentIds { get; set; }
        public bool IsRevoke { get; set; }
        public bool IsConfirm { get; set; }
    }
}
