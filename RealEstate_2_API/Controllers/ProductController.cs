using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_2_API.Dtos.FeatureDtos;
using RealEstate_2_API.Dtos.ProductDtos;
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

        [HttpPost]

        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            _productRepo.CreateProduct(createProductDto);
            return Ok("Product Başarılı Bir Şekilde Eklendi!");

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            _productRepo.DeleteProduct(id);
            return Ok("Product Silindi!");
        }
        [HttpPut]

        public async Task<IActionResult> UpdateProduct(UpdateCategoryDto updateCategoryDto)
        {
            _productRepo.UpdateProduct(updateCategoryDto);
            return Ok("Ürün Kategori Güncellendi!");

        }

        

    }
}
