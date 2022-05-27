using SalePurchase.DTO;
using SalePurchase.Helper;

namespace SalePurchase.IRepository
{
    public interface IPurchase
    {
        public Task<MessageHelper> createPurchase(CommonPurchesDTO create);
        public Task<List<ItemwiseDailyPurchaseDTO>> itemWiseDailyReport(long itemid, DateTime reportdate);
    }
}
