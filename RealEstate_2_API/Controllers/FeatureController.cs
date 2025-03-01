using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_2_API.Repositories.FeatureRepositories;

namespace RealEstate_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureRepo _featureRepo;

        public FeatureController(IFeatureRepo featureRepo)
        {
            _featureRepo = featureRepo;
        }

        [HttpGet]

        public async Task<IActionResult> GetFeatureList()
        {
            var values = await _featureRepo.GetListFeatureAsync();
            return Ok(values);
        }
    }
}
