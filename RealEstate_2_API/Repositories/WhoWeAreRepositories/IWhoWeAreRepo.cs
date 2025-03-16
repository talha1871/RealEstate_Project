using RealEstate_2_API.Dtos.WhoWeAreDtos;

namespace RealEstate_2_API.Repositories.WhoWeAreRepositories
{
    public interface IWhoWeAreRepo
    {
        public Task<List<ResultWhoWeAreDto>> GetWhoWeAreList();
        public void CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto);

        public void DeleteWhoWeAre(int id);
        public void UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto);
        public Task<GetByIDWhoWeAre> GetWhoWeAreByID(int id);
    }
}
