using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_2_API.Repositories.AgentRepositories;

namespace RealEstate_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IAgentRepo _agentRepo;

        public EmployeeController(IAgentRepo agentRepo)
        {
            _agentRepo = agentRepo;
        }

        [HttpGet]

        public async Task<IActionResult> GetAgentList()
        {
            var values = await _agentRepo.GetListAgent();
            return Ok(values);
        }



    }
}
