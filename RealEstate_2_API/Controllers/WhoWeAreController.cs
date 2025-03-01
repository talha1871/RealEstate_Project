using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
