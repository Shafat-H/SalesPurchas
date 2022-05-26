using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalePurchase.DTO;
using SalePurchase.IRepository;

namespace SalePurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItem repository;

        public ItemsController(IItem Repository)
        {
            repository = Repository;
        }
        [HttpPost]
        [Route("createItem")]
        public async Task<IActionResult> createItem(List<createItemDTO> create)
        {
            try
            {
                var data =await repository.createItem(create);
                if(data == null)
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
        [HttpPut]
        [Route("editItem")]
        public async Task<IActionResult> editItem(ItemDTO edit)
        {
            try
            {
                var data =await repository.editItem(edit);
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
