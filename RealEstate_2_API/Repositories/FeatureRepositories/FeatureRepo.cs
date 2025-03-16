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

        public async void UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            string query = "Update About Set AboutTitle1=@aboutTitle1, AboutTitle2=@aboutTitle2, AboutTitle3=@aboutTitle3,AboutTitle4=@aboutTitle4," +
                "AboutDescription1=@abouDescription1,AboutDescription2=@aboutDescription2," +
                "AboutDescription3=@aboutDescription3,AboutDescription4=@aboutDescription4, where AboutID=@aboutID";
            var parameter = new DynamicParameters();
            parameter.Add("@aboutTitle1", updateFeatureDto.AboutTitle1);
            parameter.Add("@aboutTitle2", updateFeatureDto.AboutTitle2);
            parameter.Add("@aboutTitle3", updateFeatureDto.AboutTitle3);
            parameter.Add("@aboutTitle4", updateFeatureDto.AboutTitle4);
            parameter.Add("@aboutDescription1", updateFeatureDto.AboutDescription1);
            parameter.Add("@aboutDescription2", updateFeatureDto.AboutDescription2);
            parameter.Add("@aboutDescription3", updateFeatureDto.AboutDescription3);
            parameter.Add("@aboutDescription4", updateFeatureDto.AboutDescription4);

            using (var cnt = _context.CreateConnection())
            {
                await cnt.ExecuteAsync(query, parameter);
            }
        
        
        }
    }
}
