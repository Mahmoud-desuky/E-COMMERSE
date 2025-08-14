using Back.Core.Entities;
using Back.Infrastracture.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenaricRepository<Product> _productRepository;
        public ProductController(IGenaricRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById (int Id)
        {
            return Ok(await _productRepository.GetByIdAsync(Id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepository.GetAllAsync().ToListAsync());
        }

    }
}
