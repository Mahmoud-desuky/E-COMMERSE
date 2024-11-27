using Back.Infrastracture.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }
        [HttpGet("GetById/{Id:long}")]
        public async Task<IActionResult> GetById (long Id)
        {
            try
            {
                return Ok(_product.GetByID(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
