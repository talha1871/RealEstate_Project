using RealEstate_2_API.Dtos.FeatureDtos;

namespace RealEstate_2_API.Repositories.FeatureRepositories
{
    public interface IFeatureRepo
    {
        public Task<List<ResultFeatureDto>>GetListFeatureAsync();

        public void UpdateFeature(UpdateFeatureDto updateFeatureDto);
    }
}
