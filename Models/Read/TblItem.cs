using System;
using System.Collections.Generic;

namespace SalePurchase.Models.Read
{
    public partial class TblItem
    {
        public long IntItemId { get; set; }
        public string StrItemName { get; set; } = null!;
        public decimal? NumStockQuantity { get; set; }
        public bool? IsActive { get; set; }
    }
}
