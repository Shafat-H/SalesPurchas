using SalePurchase.DTO;
using SalePurchase.Helper;

namespace SalePurchase.IRepository
{
    public interface IPurchase
    {
        public Task<MessageHelper> createPurchase(CommonPurchesDTO create);
    }
}
