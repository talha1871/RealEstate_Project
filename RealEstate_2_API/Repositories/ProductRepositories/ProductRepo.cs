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
            string query = "select * from ProductTwo";
            using (var context = _context.CreateConnection()) 
            {
                var values = await context.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            
            }
        }
        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithAsync()
        {
            string query = "select ProductID, ProductTitle, ProductPrice, ProductImage, ProductAddress, ProductCity, ProductDistrict, CategoryName from ProductTwo inner join Category on ProductTwo.ProductCategory = Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async void CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (ProductTitle, ProductPrice, ProductImage, ProductCity, ProductDistrict" +
                "ProductAddress, ProductCategory) values (@productTitle,@productPrice,@productImage," +
                "@productCity,@productDistrict," +
                "@productAddress,@productCategory)";
            var parameter = new DynamicParameters();
            parameter.Add("@productTitle", createProductDto.ProductTitle);
            parameter.Add("@productPrice", createProductDto.ProductPrice);
            parameter.Add("@productImage", createProductDto.ProductImage);
            parameter.Add("@productCity", createProductDto.ProductCity);
            parameter.Add("@productDistrict", createProductDto.ProductDistrict);
            parameter.Add("@productAddress", createProductDto.ProductAddress);
            parameter.Add("@productCategory", createProductDto.ProductCategory);
            using (var cnt = _context.CreateConnection())
            {
                await cnt.ExecuteAsync(query, parameter);
            }
        }

        public async void DeleteProduct(int id)
        {
            string query = "delete from Product where ProductID = @productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }

        public async void UpdateProduct(UpdateCategoryDto updateCategoryDto)
        {
            string query = "Update Product Set ProductTitle=@productTitle, " +
                "ProductPrice=@productPrice, ProductImage=@productImage, ProductCity=@productCity," +
                "ProductDistrict=@productDistrict,ProductAddress=@productAddress,ProductCategory=@productCategory," +
                " where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productTitle", updateCategoryDto.ProductTitle);
            parameters.Add("@productPrice", updateCategoryDto.ProductPrice);
            parameters.Add("@productImage", updateCategoryDto.ProductImage);
            parameters.Add("@productCity", updateCategoryDto.ProductCity);
            parameters.Add("@productDistrict",updateCategoryDto.ProductDistrict);
            parameters.Add("@productAddress", updateCategoryDto.ProductAddress);
            parameters.Add("@productCategory", updateCategoryDto.ProductCategory);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
