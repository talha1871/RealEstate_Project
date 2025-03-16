using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_2_API.Dtos.EmployeeDtos;
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

        [HttpPut]

        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto) //Kategori Silme İşlemi Adım-3
        {
            _agentRepo.UpdateAgent(updateEmployeeDto);
            return Ok("Employee Başarılı Bir Şekilde Güncellendi!");
        }

        [HttpPost]

        public async Task<IActionResult> CreateAgent(CreateEmployeeDto createEmployeeDto)
        {
            _agentRepo.CreateAgent(createEmployeeDto);
            return Ok("Employee Başarıyla Eklendi!");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteEmployee(int id) //Kategori Silme İşlemi Adım-3
        {
            _agentRepo.DeleteAgent(id);
            return Ok("Employee Başarılı Bir Şekilde Silindi!");
        }

    }
}
