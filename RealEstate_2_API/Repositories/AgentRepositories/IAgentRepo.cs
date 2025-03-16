
using RealEstate_2_API.Dtos.AgentDtos;
using RealEstate_2_API.Dtos.EmployeeDtos;

namespace RealEstate_2_API.Repositories.AgentRepositories
{
    public interface IAgentRepo
    {   // Employee Kısmı
        public Task<List<ResultAgentDto>> GetListAgent();

        public void CreateAgent(CreateEmployeeDto createEmployeeDto); // Çalışan ekleme işlemi

        public void DeleteAgent(int id);

        public void UpdateAgent(UpdateEmployeeDto updateEmployeeDto);
    }
}
