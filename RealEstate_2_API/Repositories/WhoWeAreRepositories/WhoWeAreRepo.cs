using Dapper;
using RealEstate_2_API.Dtos.WhoWeAreDtos;
using RealEstate_2_API.Models.D_Context;

namespace RealEstate_2_API.Repositories.WhoWeAreRepositories
{
    public class WhoWeAreRepo : IWhoWeAreRepo
    {
        private readonly Context _context;

        public WhoWeAreRepo(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultWhoWeAreDto>> GetWhoWeAreList()
        {
            string query = "Select * From WhoWeAre";
            using (var cnt = _context.CreateConnection())
            {
                var values = await cnt.QueryAsync<ResultWhoWeAreDto>(query);
                return values.ToList();
                
            }
            
        }
    }
}
