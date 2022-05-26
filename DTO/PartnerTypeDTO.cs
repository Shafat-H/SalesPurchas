namespace SalePurchase.DTO
{
    public class PartnerTypeDTO
    {
        public long IntPartnerTypeId { get; set; }
        public string StrPartnerTypeName { get; set; } = null!;
        public bool? IsActive { get; set; }
    }
    public class createPartnerTypeDTO
    {
        public string StrPartnerTypeName { get; set; } = null!;
    }
}
