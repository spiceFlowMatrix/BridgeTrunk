﻿using System;
using System.Collections.Generic;
using System.Text;
using Bridge.Domain.Common;

namespace Bridge.Domain.Entities
{
    public class SalesAgent : AuditableEntity
    {
        public string AgentName { get; set; }
        public long AgentCategoryId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        //New fields
        public string PartnerBackgroud { get; set; }
        public string FocalPoint { get; set; }
        public string Position { get; set; }
        public string PhysicalAddress { get; set; }
        public string CurrencyCode { get; set; }
        public int AgreedMonthlyDeposit { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }
    }
}