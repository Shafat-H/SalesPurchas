namespace SalePurchase.DTO
{
    public class PurchaseDTO
    {
        public long IntPurchaseId { get; set; }
        public long IntSupplierId { get; set; }
        public DateTime? DtePurchaseDate { get; set; }
        public bool? IsActive { get; set; }
    }

    public class CreatePurchaseDTO
    {
        public long IntSupplierId { get; set; }
    }
    public class PurchaseDetailsDTO
    {
        public long IntDetailsId { get; set; }
        public long? IntPurchaseId { get; set; }
        public long? IntItemId { get; set; }
        public decimal? NumItemQuantity { get; set; }
        public decimal? NumUnitPrice { get; set; }
        public bool? IsActive { get; set; }
    }
    public class CreatePurchaseDetailsDTO
    {
        public long? IntPurchaseId { get; set; }
        public long? IntItemId { get; set; }
        public decimal? NumItemQuantity { get; set; }
        public decimal? NumUnitPrice { get; set; }
    }

    public class CommonPurchesDTO
    {
        public CreatePurchaseDTO Head { get; set; }
        public List<CreatePurchaseDetailsDTO> Row { get; set; }
    }
}
