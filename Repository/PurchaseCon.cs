using SalePurchase.DbContexts;
using SalePurchase.DTO;
using SalePurchase.Helper;
using SalePurchase.IRepository;
using System.Linq;

namespace SalePurchase.Repository
{
    public class PurchaseCon : IPurchase
    {
        private readonly ReadDbContext contextR;
        private readonly WriteDbContext contextW;

        public PurchaseCon(ReadDbContext ContextR, WriteDbContext ContextW)
        {
            contextR = ContextR;
            contextW = ContextW;
        }
        public async Task<MessageHelper> createPurchase(CommonPurchesDTO create)
        {
            try
            {
                var entity = new Models.Write.TblPurchase()
                {
                    IntSupplierId = create.Head.IntSupplierId,
                    DtePurchaseDate = DateTime.Now,
                    IsActive = true
                };

                await contextW.TblPurchases.AddAsync(entity);
                await contextW.SaveChangesAsync();

                var puDetailsList = new List<Models.Write.TblPurchaseDetail>();
                var itemlist = new List<Models.Write.TblItem>();
                foreach (var item in create.Row)
                {
                    var itm = contextW.TblItems.Where(x => x.IntItemId == item.IntItemId).FirstOrDefault();
                    if (itm != null)
                    {
                        itm.NumStockQuantity = item.NumItemQuantity;
                        itemlist.Add(itm);
                        var ent = new Models.Write.TblPurchaseDetail()
                        {
                            IntPurchaseId = entity.IntPurchaseId,
                            IntItemId = item.IntItemId,
                            NumItemQuantity = item.NumItemQuantity,
                            NumUnitPrice = item.NumUnitPrice,
                            IsActive = true
                        };
                        puDetailsList.Add(ent);
                    }
                }

                if (puDetailsList.Count > 0)
                {
                    contextW.TblPurchaseDetails.AddRange(puDetailsList);
                    await contextW.SaveChangesAsync();
                }
                if (itemlist.Count > 0)
                {
                    contextW.TblItems.UpdateRange(itemlist);
                    await contextW.SaveChangesAsync();
                }
                return new MessageHelper()
                {
                    Message = "Purches Successfully",
                    statuscode = 200
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ItemwiseDailyPurchaseDTO>> itemWiseDailyReport(long itemid, DateTime reportdate)
        {
            try
            {
                var data = await Task.FromResult((from a in contextR.TblPurchaseDetails
                                                  join b in contextR.TblItems on a.IntItemId equals b.IntItemId
                                                  where a.IntItemId == itemid
                                                  && a.IsActive == true
                                                  group new { a, b } by new { a.IntItemId, b.StrItemName, b.NumStockQuantity } into g
                                                  select new ItemwiseDailyPurchaseDTO
                                                  {
                                                      IntItemId = g.Key.IntItemId,
                                                      StrItemName = g.Key.StrItemName,
                                                      NumStockQuantity=g.Key.NumStockQuantity,
                                                      TotalNumItemQuantity=g.Sum(x=>x.a.NumItemQuantity),
                                                      TotalNumItemCost=g.Sum(x=>x.a.NumUnitPrice*x.a.NumItemQuantity)
                                                  }).ToList());
                return data;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
