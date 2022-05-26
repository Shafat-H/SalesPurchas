using Microsoft.EntityFrameworkCore;
using SalePurchase.DbContexts;
using SalePurchase.DTO;
using SalePurchase.Helper;
using SalePurchase.IRepository;

namespace SalePurchase.Repository
{
    public class ItemConfig : IItem
    {
        private readonly ReadDbContext _contextR;
        private readonly WriteDbContext _contextW;

        public ItemConfig(ReadDbContext contextR,WriteDbContext contextW)
        {
            _contextR = contextR;
            _contextW = contextW;
        }
        #region ===================Create-Items===============
        public async Task<MessageHelper> createItem(List<createItemDTO> create)
        {
            try
            {
                var list = new List<Models.Write.TblItem>();


                foreach (var item in create)
                {
                    var data = _contextW.TblItems.Where(x=>x.StrItemName.ToLower() == item.StrItemName.ToLower()).FirstOrDefault();
                    if(data==null)
                    {
                        var entity = new Models.Write.TblItem()
                        {
                            StrItemName = item.StrItemName,
                            NumStockQuantity =0,
                            IsActive = true,
                        };
                        list.Add(entity);
                    }
                }
                
                await _contextW.TblItems.AddRangeAsync(list);
                await _contextW.SaveChangesAsync();

                return new MessageHelper()
                {
                    Message = "create Successfully",
                    statuscode = 200,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        public async Task<MessageHelper> editItem(ItemDTO edit)
        {
            try
            {
                var data = _contextW.TblItems.Where(x => x.IntItemId == edit.IntItemId && x.IsActive == true).FirstOrDefault();
                if(data== null)
                {
                    throw new Exception("Item Not Found");
                }
                data.StrItemName = edit.StrItemName;
                data.NumStockQuantity = edit.NumStockQuantity;

                _contextW.TblItems.Update(data);
                await _contextW.SaveChangesAsync();

                return new MessageHelper()
                {
                    Message = "Update Successfully",
                    statuscode = 200,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region============Delete-Item================
        public async Task<MessageHelper> deleteItem(int id)
        {
            try
            {
                var data = _contextW.TblItems.Where(x => x.IntItemId == id && x.IsActive == true).FirstOrDefault();
                if(data==null)
                {
                    throw new Exception("Item not Found");
                }
                data.IsActive = false;
                _contextW.TblItems.Update(data);
                await _contextW.SaveChangesAsync();

                return new MessageHelper()
                {
                    Message = "Delete Successfullt",
                    statuscode = 200,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region==================Get Item By Id==========
        public async Task<ItemDTO> getItem(int id)
        {
            try
            {
                var item = await Task.FromResult((from a in _contextR.TblItems
                                                  where a.IntItemId == id
                                                  && a.IsActive == true
                                                  select new ItemDTO
                                                  {
                                                      IntItemId = a.IntItemId,
                                                      StrItemName=a.StrItemName,
                                                      NumStockQuantity=a.NumStockQuantity,
                                                      IsActive=a.IsActive
                                                  }).FirstOrDefault());
                if(item == null)
                {
                    throw new Exception("Item Not Found");
                }
                return item;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion

    }
}
