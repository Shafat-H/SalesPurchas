﻿using System;
using System.Collections.Generic;

namespace SalePurchase.Models.Write
{
    public partial class TblPartner
    {
        public long IntPartnerId { get; set; }
        public string StrPartnerName { get; set; } = null!;
        public long? IntPartnerTypeId { get; set; }
        public bool? IsActive { get; set; }
    }
}
