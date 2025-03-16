using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_2_API.Repositories.StatisticsRepositories;

namespace RealEstate_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepositories _statisticsRepositories;

        public StatisticsController(IStatisticsRepositories statisticsRepositories)
        {
            _statisticsRepositories = statisticsRepositories;
        }

        [HttpGet("ActiveCategoryCount")]

        public IActionResult GetStatistics() 
        {
            return Ok(_statisticsRepositories.ActiveCategoryCount());
        }

        [HttpGet("ActiveEmployeeCount")]

        public IActionResult GetActiveEmployeeStatistics()
        {
            return Ok(_statisticsRepositories.ActiveEmployeeCount());
        }

        [HttpGet("PassiveCategoryCount")]

        public IActionResult GetPassiveCategoryCountStatistics()
        {
            return Ok(_statisticsRepositories.PassiveCategoryCount());
        }

        [HttpGet("CategoryCount")]

        public IActionResult PassiveCategoryCount()
        {
            return Ok(_statisticsRepositories.PassiveCategoryCount());
        }
        [HttpGet("TotalProductCount")]

        public IActionResult TotalProductCount()
        {
            return Ok(_statisticsRepositories.TotalProductCount());
        }


        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount()
        {
            return Ok(_statisticsRepositories.ApartmentCount());
        }

        [HttpGet("DifferentCityCount")]
        public IActionResult DifferentCityCount()
        {
            return Ok(_statisticsRepositories.DifferentCityCount());
        }
        [HttpGet("AverageRoomCount")]
        public IActionResult AverageRoomCount()
        {
            return Ok(_statisticsRepositories.AverageRoomCount());
        }

        [HttpGet("AverageProductPriceByRent")]
        public IActionResult AverageProductPriceByRent()
        {
            return Ok(_statisticsRepositories.AverageProductPriceByRent());
        }


        [HttpGet("AverageProductPriceBySale")]
        public IActionResult AverageProductPriceBySale()
        {
            return Ok(_statisticsRepositories.AverageProductPriceBySale());
        }

        [HttpGet("CategoryNameByMaxProductCount")]
        public IActionResult CategoryNameByMaxProductCount()
        {
            return Ok(_statisticsRepositories.CategoryNameByMaxProductCount());
        }
        [HttpGet("CityNameByMaxProductCount")]
        public IActionResult CityNameByMaxProductCount()
        {
            return Ok(_statisticsRepositories.CityNameByMaxProductCount());
        }
        [HttpGet("EmployeeNameByMaxProductCount")]
        public IActionResult EmployeeNameByMaxProductCount()
        {
            return Ok(_statisticsRepositories.EmployeeNameByMaxProductCount());
        }
        [HttpGet("LastProductPrice")]
        public IActionResult LastProductPrice()
        {
            return Ok(_statisticsRepositories.LastProductPrice());
        }
        [HttpGet("TheNewestBuilding")]
        public IActionResult TheNewestBuilding()
        {
            return Ok(_statisticsRepositories.TheNewestBuilding());
        }
        [HttpGet("TheOldestBuilding")]
        public IActionResult TheOldestBuilding()
        {
            return Ok(_statisticsRepositories.TheOldestBuilding());
        }
    }
}
