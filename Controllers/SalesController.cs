using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalePurchase.DTO;
using SalePurchase.IRepository;

namespace SalePurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISales repository;

        public SalesController(ISales Repository)
        {
            repository = Repository;
        }
        [HttpPost]
        [Route("createSales")]
        public async Task<IActionResult> createSales(CommonSalesDTO create)
        {
            var data= await repository.createSales(create);
            return Ok(data);
        }
    }
}
