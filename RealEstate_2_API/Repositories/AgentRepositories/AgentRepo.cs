using Dapper;
using RealEstate_2_API.Dtos.AgentDtos;
using RealEstate_2_API.Models.D_Context;

namespace RealEstate_2_API.Repositories.AgentRepositories
{
    public class AgentRepo : IAgentRepo
    {
        private readonly Context _context;

        public AgentRepo(Context context)
        {
            _context = context;
        }

       

        public async Task<List<ResultAgentDto>> GetListAgent()
        {
            string query = "select * from Employee";
            using (var cnt = _context.CreateConnection())
            {
                var value = await cnt.QueryAsync<ResultAgentDto>(query);
                return value.ToList();
            }
        }

       
    }
}
