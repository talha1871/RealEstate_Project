
using RealEstate_2_API.Dtos.AgentDtos;

namespace RealEstate_2_API.Repositories.AgentRepositories
{
    public interface IAgentRepo
    {
        public Task<List<ResultAgentDto>> GetListAgent();
        
    }
}
