using RealEstate_2_API.Dtos.ProductDtos;

namespace RealEstate_2_API.Repositories.ProductRepositories
{
    public interface IProductRepo
    {
        public Task<List<ResultProductDto>> GetProductsAsync();

        public Task<List<ResultProductWithCategoryDto>> GetAllProductWithAsync();
    }
}
