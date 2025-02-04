using Back.Infrastracture.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Back.API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById (int Id)
        {
            return Ok(await _product.GetById(Id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _product.GetAll());
        }

    }
}
