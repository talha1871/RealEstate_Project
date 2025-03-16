using RealEstate_2_API.Dtos.ProductDtos;

namespace RealEstate_2_API.Repositories.ProductRepositories
{
    public interface IProductRepo
    {
        public Task<List<ResultProductDto>> GetProductsAsync();

        public void CreateProduct(CreateProductDto createProductDto);
        public void DeleteProduct(int id);
        public void UpdateProduct(UpdateCategoryDto updateCategoryDto);

        public Task<List<ResultProductWithCategoryDto>> GetAllProductWithAsync();
    }
}
