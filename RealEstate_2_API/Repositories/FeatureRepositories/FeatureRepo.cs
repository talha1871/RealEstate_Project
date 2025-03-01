using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_2_API.Dtos.FeatureDtos;
using RealEstate_2_API.Models.D_Context;

namespace RealEstate_2_API.Repositories.FeatureRepositories
{
    public class FeatureRepo : IFeatureRepo
    {
        private readonly Context _context;

        public FeatureRepo(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultFeatureDto>> GetListFeatureAsync()
        {
            string query = "select * from About";
            using (var cnt = _context.CreateConnection())
            {
                var values = await cnt.QueryAsync<ResultFeatureDto>(query);
                return values.ToList();
            }  
        }



    }
}
