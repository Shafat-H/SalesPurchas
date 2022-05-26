using System;
using System.Collections.Generic;

namespace SalePurchase.Models.Read
{
    public partial class TblPurchaseDetail
    {
        public long IntDetailsId { get; set; }
        public long? IntPurchaseId { get; set; }
        public long? IntItemId { get; set; }
        public decimal? NumItemQuantity { get; set; }
        public decimal? NumUnitPrice { get; set; }
        public bool? IsActive { get; set; }
    }
}
