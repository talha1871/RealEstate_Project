using RealEstate_2_API.Dtos.CategoryDtos;

namespace RealEstate_2_API.Repositories.CategoryRepositories
{
    public interface ICategoryRepo
    {
        public Task<List<ResultCategoryDto>> GetAllCategoryAsync();

        public void CreateCategory(CreateCategoryDto categoryDto); // Kategori ekleme işlemi

        public void DeleteCategory(int id); // Kategori Silme İşlemi Adım-1

        public void UpdateCategory(UpdatedCategoryDto categoryDto); // Kategori Update İşlemi Adım-1

        public Task<GetByIDCategoryDto> GetByID(int id); // ID'ye göre kategori getirme Adım-1




    }   
}
