namespace SalePurchase.DTO
{
    public class SalesDTO
    {
        public long IntSalesId { get; set; }
        public long? IntCustomerId { get; set; }
        public DateTime? DteSalesDate { get; set; }
        public bool? IsActive { get; set; }
    }

    public class CreateSalesDTO
    {
        public long? IntCustomerId { get; set; }
    }


    public class SalesDetailsDTO
    {
        public long IntDetailsId { get; set; }
        public long? IntSalesId { get; set; }
        public long? IntItemId { get; set; }
        public decimal? NumItemQuantity { get; set; }
        public decimal? NumUnitPrice { get; set; }
        public bool? IsActive { get; set; }
    }
    public class CreateSalesDetailsDTO
    {
        public long? IntSalesId { get; set; }
        public long? IntItemId { get; set; }
        public decimal? NumItemQuantity { get; set; }
        public decimal? NumUnitPrice { get; set; }
    }


    public class CommonSalesDTO
    {
        public CreateSalesDTO head { get; set; }
        public List<CreateSalesDetailsDTO> row { get; set; }
    }
}
