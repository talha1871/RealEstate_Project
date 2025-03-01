using RealEstate_2_API.Dtos.WhoWeAreDtos;

namespace RealEstate_2_API.Repositories.WhoWeAreRepositories
{
    public interface IWhoWeAreRepo
    {
        public Task<List<ResultWhoWeAreDto>> GetWhoWeAreList();
    }
}
