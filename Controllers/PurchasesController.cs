using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalePurchase.DTO;
using SalePurchase.IRepository;

namespace SalePurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchase repository;

        public PurchasesController(IPurchase Repository)
        {
            repository = Repository;
        }
        [HttpPost]
        [Route("createPurchase")]
        public async Task<IActionResult> createPurchase(CommonPurchesDTO create)
        {
            var data =await repository.createPurchase(create);
            return Ok(data);
        }

        [HttpGet]
        [Route("itemWiseDailyReport")]
        public async Task<List<ItemwiseDailyPurchaseDTO>> itemWiseDailyReport(long itemid, DateTime reportdate)
        {
            var data  =  await repository.itemWiseDailyReport(itemid, reportdate);
            return data;
        }
    }
}
