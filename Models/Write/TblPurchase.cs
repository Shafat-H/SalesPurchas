﻿using System;
using System.Collections.Generic;

namespace SalePurchase.Models.Write
{
    public partial class TblPurchase
    {
        public long IntPurchaseId { get; set; }
        public long IntSupplierId { get; set; }
        public DateTime DtePurchaseDate { get; set; }
        public bool IsActive { get; set; }
    }
}
