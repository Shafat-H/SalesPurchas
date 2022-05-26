using SalePurchase.DTO;
using SalePurchase.Helper;

namespace SalePurchase.IRepository
{
    public interface IPartnerTypee
    {
        public Task<MessageHelper> createPartnerType(createPartnerTypeDTO create);
    }
}
