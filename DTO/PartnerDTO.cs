namespace SalePurchase.DTO
{
    public class PartnerDTO
    {
        public long IntPartnerId { get; set; }
        public string StrPartnerName { get; set; } = null!;
        public long? IntPartnerTypeId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class createPartnerDTO
    {
        public string StrPartnerName { get; set; } = null!;
        public long? IntPartnerTypeId { get; set; }
    }
}
