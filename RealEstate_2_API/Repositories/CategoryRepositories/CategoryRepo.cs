using Dapper;
using RealEstate_2_API.Dtos.CategoryDtos;
using RealEstate_2_API.Models.D_Context;

namespace RealEstate_2_API.Repositories.CategoryRepositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly Context _context;

        public CategoryRepo(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "select * from Category";
            using (var cnt = _context.CreateConnection())
            {
                var values = await cnt.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
            

        }

        public async void CreateCategory(CreateCategoryDto categoryDto) // Kategori ekleme işlemi
        {
            string query = "insert into Category (CategoryName, CategoryStatus) values(@categoryName, @categoryStatus)";

            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // Ekleme-silme-güncelleme için ExecuteASYNC KULLANILIR
            }

        }


        public async void DeleteCategory(int id)  // Kategori Silme İşlemi Adım-2
        {
            string query = "delete from Category Where CategoryID=@categoryID";

            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }

        }

        public async void UpdateCategory(UpdatedCategoryDto categoryDto) //Kategori Update İşlemi Adım-2
        {
            string query = "Update Category Set CategoryName=@categoryName, CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
            parameters.Add("@categoryID", categoryDto.CategoryID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }


        }

        public async Task<GetByIDCategoryDto> GetByID(int id) //ID'ye göre kategori getirme Adım-2
        {
            string query = "Select * From Category Where CategoryID=@CategoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", id);
            using (var connection = _context.CreateConnection())
            {
                var getID = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, parameters); // Sadece bir değer döndürür. Gönderdiğim kategorinin id bilgisi geli. Diğerleri gelmez!

                return getID;
            }
        }


    }
}
