using SalePurchase.DTO;
using SalePurchase.Helper;

namespace SalePurchase.IRepository
{
    public interface ISales
    {
        public Task<MessageHelper> createSales(CommonSalesDTO create);
    }
}
