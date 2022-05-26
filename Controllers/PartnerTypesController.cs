using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalePurchase.DbContexts;
using SalePurchase.DTO;
using SalePurchase.IRepository;

namespace SalePurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerTypesController : ControllerBase
    {
        private readonly IPartnerTypee repository;

        public PartnerTypesController(IPartnerTypee Repository)
        {
            repository = Repository;
        }
        [HttpPost]
        [Route("createPartnerType")]
        public async Task<IActionResult> createPartnerType(createPartnerTypeDTO create)
        {
            var data  =await repository.createPartnerType(create);
            return Ok(data);
        }
    }
}