using SalePurchase.DTO;
using SalePurchase.Helper;

namespace SalePurchase.IRepository
{
    public interface IItem
    {
        public Task<MessageHelper> createItem(List<createItemDTO> create);

        public Task<MessageHelper> editItem(ItemDTO edit);
        public Task<ItemDTO> getItem(int id);
        public Task<MessageHelper> deleteItem(int id);
    }
}
