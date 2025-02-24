using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_2_API.Repositories.ProductRepositories;

namespace RealEstate_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]   
        public async Task<IActionResult> GetProduct()
        {
            var value = await _productRepo.GetProductsAsync(); 
            return Ok(value);
        }

        [HttpGet("ProductwithCategory")]

        public async Task<IActionResult> GetProductWithCategory()
        {
            var value = await _productRepo.GetAllProductWithAsync(); 
            return Ok(value);
        }
    }
}
