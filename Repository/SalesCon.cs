using SalePurchase.DbContexts;
using SalePurchase.DTO;
using SalePurchase.Helper;
using SalePurchase.IRepository;

namespace SalePurchase.Repository
{
    public class SalesCon:ISales
    {
        private readonly ReadDbContext contextR;
        private readonly WriteDbContext contextW;

        public SalesCon(ReadDbContext ContextR,WriteDbContext ContextW)
        {
            contextR = ContextR;
            contextW = ContextW;
        }

        public async Task<MessageHelper> createSales(CommonSalesDTO create)
        {
            using var transaction = await contextW.Database.BeginTransactionAsync();
            try
            {
                var saleshead = new Models.Write.TblSale()
                {
                    IntCustomerId = create.head.IntCustomerId,
                    DteSalesDate = DateTime.Now,
                    IsActive = true,
                };
                contextW.TblSales.Add(saleshead);
                await contextW.SaveChangesAsync();

                var rowList = new List<Models.Write.TblSalesDetail>();
                var itemlist = new List<Models.Write.TblItem>();

                foreach (var item in create.row)
                {
                    var salesdetails = contextW.TblItems.Where(x => x.IntItemId == item.IntItemId && x.IsActive==true).FirstOrDefault();

                    if(salesdetails != null)
                    {
                        if (salesdetails.NumStockQuantity >= item.NumItemQuantity)
                        {
                            salesdetails.NumStockQuantity = salesdetails.NumStockQuantity - item.NumItemQuantity;
                            itemlist.Add(salesdetails);

                            var salesrow = new Models.Write.TblSalesDetail()
                            {
                                IntSalesId = saleshead.IntSalesId,
                                IntItemId = item.IntItemId,
                                NumItemQuantity = item.NumItemQuantity,
                                NumUnitPrice=item.NumUnitPrice,
                                IsActive= true
                            };
                            rowList.Add(salesrow);
                        }
                    }
                }

                if(itemlist.Count > 0)
                {
                    contextW.TblItems.UpdateRange(itemlist);
                    await contextW.SaveChangesAsync();
                }
                if(rowList.Count > 0)
                {
                    await contextW.TblSalesDetails.AddRangeAsync(rowList);
                    await contextW.SaveChangesAsync();
                }

                await transaction.CommitAsync();
                return new MessageHelper()
                {
                    Message="Sales Successfully",
                    statuscode=200
                };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
