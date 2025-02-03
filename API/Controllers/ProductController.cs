using Back.Core.Entities;
using Back.Infrastracture.Interface;
using Back.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.API.Controllers
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
