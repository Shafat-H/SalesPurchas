using SalePurchase.DbContexts;
using SalePurchase.DTO;
using SalePurchase.Helper;
using SalePurchase.IRepository;

namespace SalePurchase.Repository
{
    public class PartnerTypeConfig : IPartnerTypee
    {
        private readonly ReadDbContext _contextR;
        private readonly WriteDbContext _contextW;

        public PartnerTypeConfig(ReadDbContext contextR,WriteDbContext contextW)
        {
            _contextR = contextR;
            _contextW = contextW;
        }
        public async Task<MessageHelper> createPartnerType(createPartnerTypeDTO create)
        {
            try
            {
                var data = _contextW.TblPartnerTypes.Where(x => x.StrPartnerTypeName.ToLower() == create.StrPartnerTypeName.ToLower() && x.IsActive == true).FirstOrDefault();
                if (data == null)
                {
                    var entity = new Models.Write.TblPartnerType()
                    {
                        StrPartnerTypeName = create.StrPartnerTypeName,
                        IsActive = true
                    };
                    await _contextW.TblPartnerTypes.AddAsync(entity);
                    await _contextW.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Partner Type Already Exit");
                }
                return new MessageHelper()
                {
                    Message = "Partner Type Create Successfully",
                    statuscode = 200
                };
            }
            catch (Exception)
            {

                throw;
            }
            
            

        }
    }
}
