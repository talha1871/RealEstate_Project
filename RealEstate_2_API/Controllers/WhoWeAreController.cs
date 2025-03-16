using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_2_API.Dtos.CategoryDtos;
using RealEstate_2_API.Dtos.WhoWeAreDtos;
using RealEstate_2_API.Repositories.WhoWeAreRepositories;

namespace RealEstate_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreController : ControllerBase
    {
        private readonly IWhoWeAreRepo _whoWeAreRepo;

        public WhoWeAreController(IWhoWeAreRepo whoWeAreRepo)
        {
            _whoWeAreRepo = whoWeAreRepo;
        }

        [HttpGet]

        public async Task<IActionResult> GetListWhoWeAre()
        { 
            var values = await _whoWeAreRepo.GetWhoWeAreList();
            return Ok(values);
        
        }

        [HttpPost]

        public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto)
        {
            _whoWeAreRepo.CreateWhoWeAre(createWhoWeAreDto);
            return Ok("WhoWeAre Başarılı Bir Şekilde Eklendi!");

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteWhoWeAre(int id) //Kategori Silme İşlemi Adım-3
        {
            _whoWeAreRepo.DeleteWhoWeAre(id);
            return Ok("Kategori Başarılı Bir Şekilde Silindi!");
        }


        [HttpPut]

        public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto)
        {
            _whoWeAreRepo.UpdateWhoWeAre(updateWhoWeAreDto);
            return Ok("WhoWeAre Başarılı Bir Şekilde Güncellendi!");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetWhoWeAre(int id)
        {
            var value = await _whoWeAreRepo.GetWhoWeAreByID(id);
            return Ok(value);
        }
    }
}
