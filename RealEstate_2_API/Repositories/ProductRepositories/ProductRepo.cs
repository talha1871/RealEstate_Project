using Dapper;
using RealEstate_2_API.Dtos.ProductDtos;
using RealEstate_2_API.Models.D_Context;

namespace RealEstate_2_API.Repositories.ProductRepositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly Context _context;

        public ProductRepo(Context context)
        {
            _context = context;
        }

       
        public async Task<List<ResultProductDto>> GetProductsAsync()
        {
            string query = "select * from Product";
            using (var context = _context.CreateConnection()) 
            {
                var values = await context.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            
            }
        }


        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithAsync()
        {
            string query = "select ProductID, ProductTitle, ProductPrice, ProductCity, ProductDistrict, CategoryName from Product inner join Category on Product.ProductCategory = Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

    }
}
