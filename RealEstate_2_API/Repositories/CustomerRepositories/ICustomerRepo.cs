using RealEstate_2_API.Dtos.CustomerDtos;

namespace RealEstate_2_API.Repositories.CustomerRepositories
{
    public interface ICustomerRepo
    {
        public Task<List<ResultCustomerDto>> GetListCustomerAsync();
    }
}
