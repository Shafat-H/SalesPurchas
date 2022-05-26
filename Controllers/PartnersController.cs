using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalePurchase.DTO;
using SalePurchase.IRepository;

namespace SalePurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private readonly IPartner repository;

        public PartnersController(IPartner Repository)
        {
            repository = Repository;
        }
        [HttpPost]
        [Route("createPartner")]
        public async Task<IActionResult> createPartner(createPartnerDTO create)
        {
            try
            {
                var data=await repository.createPartner(create);
                if(data==null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
