using SalePurchase.DTO;
using SalePurchase.Helper;

namespace SalePurchase.IRepository
{
    public interface IPartner
    {
        public Task<MessageHelper> createPartner(createPartnerDTO create);
    }
}
