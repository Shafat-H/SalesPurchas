using SalePurchase.DbContexts;
using SalePurchase.DTO;
using SalePurchase.Helper;
using SalePurchase.IRepository;

namespace SalePurchase.Repository
{
    public class PartnerConfig : IPartner
    {
        private readonly ReadDbContext _contextR;
        private readonly WriteDbContext _contextW;

        public PartnerConfig(ReadDbContext contextR,WriteDbContext contextW)
        {
            _contextR = contextR;
            _contextW = contextW;
        }
        public async Task<MessageHelper> createPartner(createPartnerDTO create)
        {
            try
            {
                var partner = new Models.Write.TblPartner()
                {
                    IntPartnerTypeId = create.IntPartnerTypeId,
                    StrPartnerName = create.StrPartnerName,
                    IsActive=true
                };
                await _contextW.TblPartners.AddAsync(partner);
                await _contextW.SaveChangesAsync();

                return new MessageHelper()
                {
                    Message = "Partner Create Successfully",
                    statuscode =200
                };

            }
            catch (Exception)
            {
                throw;
            }
            

        }
    }
}
