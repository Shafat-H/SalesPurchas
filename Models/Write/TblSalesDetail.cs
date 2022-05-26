﻿using System;
using System.Collections.Generic;

namespace SalePurchase.Models.Write
{
    public partial class TblSalesDetail
    {
        public long IntDetailsId { get; set; }
        public long? IntSalesId { get; set; }
        public long? IntItemId { get; set; }
        public decimal? NumItemQuantity { get; set; }
        public decimal? NumUnitPrice { get; set; }
        public bool? IsActive { get; set; }
    }
}
