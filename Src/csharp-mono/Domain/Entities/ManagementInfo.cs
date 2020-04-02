using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Domain.Entities
{
    public class ManagementInfo : EntityBase
    {
        public string noon_background { get; set; }
        public string sales_partner_eng { get; set; }
        public string sales_partner_dari { get; set; }
        public string school_receipt_notes { get; set; }
        public string individual_receipt_notes { get; set; }
    }
}
