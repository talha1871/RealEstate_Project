using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_2_API.Dtos.CategoryDtos;
using RealEstate_2_API.Repositories.CategoryRepositories;

namespace RealEstate_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoriesController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]

        public async Task<IActionResult> GetListCategory() 
        {
            var values = await _categoryRepo.GetAllCategoryAsync();
            return Ok(values);
        
        }


        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryRepo.CreateCategory(createCategoryDto);
            return Ok("Kategori Başarılı Bir Şekilde Eklendi!");

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCategory(int id) //Kategori Silme İşlemi Adım-3
        {
            _categoryRepo.DeleteCategory(id);
            return Ok("Kategori Başarılı Bir Şekilde Silindi!");
        }


        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryRepo.UpdateCategory(updateCategoryDto);
            return Ok("Kategori Başarılı Bir Şekilde Güncellendi!");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetByID(int id)
        {
            var value = await _categoryRepo.GetByID(id);
            return Ok(value);
        }
    }
}
