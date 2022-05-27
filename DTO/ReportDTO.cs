namespace SalePurchase.DTO
{
    public class ReportDTO
    {
    }
    public class ItemwiseDailyPurchaseDTO
    {
        public long? IntItemId { get; set; }
        public string StrItemName { get; set; } = null!;
        public decimal? NumStockQuantity { get; set; }
        public decimal? TotalNumItemQuantity { get; set; }
        public decimal? TotalNumItemCost { get; set; }
    }
    
}
