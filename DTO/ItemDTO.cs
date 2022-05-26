namespace SalePurchase.DTO
{
    public class ItemDTO
    {
        public long IntItemId { get; set; }
        public string StrItemName { get; set; } = null!;
        public decimal? NumStockQuantity { get; set; }
        public bool? IsActive { get; set; }
    }
    public class createItemDTO
    {
        public string StrItemName { get; set; } = null!;
 
    }
}
