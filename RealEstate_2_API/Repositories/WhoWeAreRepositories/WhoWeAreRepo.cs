using Dapper;
using RealEstate_2_API.Dtos.CategoryDtos;
using RealEstate_2_API.Dtos.WhoWeAreDtos;
using RealEstate_2_API.Models.D_Context;

namespace RealEstate_2_API.Repositories.WhoWeAreRepositories
{
    public class WhoWeAreRepo : IWhoWeAreRepo
    {
        private readonly Context _context;

        public WhoWeAreRepo(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultWhoWeAreDto>> GetWhoWeAreList()
        {
            string query = "Select * From WhoWeAre";
            using (var cnt = _context.CreateConnection())
            {
                var values = await cnt.QueryAsync<ResultWhoWeAreDto>(query);
                return values.ToList();
                
            }
            
        }

        public async void CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto)
        {
            string query = "insert into WhoWeAre (Title1, Title2, Title3, Title4, Description1, Description2, Description3, Description4, Image) values(@Title1, @Title2, @Title3, @Title4, @Description1, @Description2, @Description3, @Description4, @Image )";

            var parameters = new DynamicParameters();
            parameters.Add("@Title1", createWhoWeAreDto.Title1);
            parameters.Add("@Title2", createWhoWeAreDto.Title1);
            parameters.Add("@Title3", createWhoWeAreDto.Title2);
            parameters.Add("@Title4", createWhoWeAreDto.Title4);
            parameters.Add("@Description1", createWhoWeAreDto.Description1);
            parameters.Add("@Description2", createWhoWeAreDto.Description2);
            parameters.Add("@Description3", createWhoWeAreDto.Description3);
            parameters.Add("@Description4", createWhoWeAreDto.Description4);
            parameters.Add("@Image", createWhoWeAreDto.Image);            
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // Ekleme-silme-güncelleme için ExecuteASYNC KULLANILIR
            }
        }

      
       

        public async void DeleteWhoWeAre(int id)
        {
            string query = "delete from WhoWeAre Where WhoWeAreID = @whoWeAreID";

            var parameters = new DynamicParameters();
            parameters.Add("@whoweareID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }
        public async void UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto)
        {
            string query = "Update WhoWeAre Set Title1=@title1, Title2=@title2, Title3=@title3, Title4=@title4, Description1=@description1, Description2=@description2, Description3=@description3, Description4=@description4 where WhoWeAreID=@whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@Title1", updateWhoWeAreDto.Title1);
            parameters.Add("@Title2", updateWhoWeAreDto.Title1);
            parameters.Add("@Title3", updateWhoWeAreDto.Title2);
            parameters.Add("@Title4", updateWhoWeAreDto.Title4);
            parameters.Add("@Description1", updateWhoWeAreDto.Description1);
            parameters.Add("@Description2", updateWhoWeAreDto.Description2);
            parameters.Add("@Description3", updateWhoWeAreDto.Description3);
            parameters.Add("@Description4", updateWhoWeAreDto.Description4);
            parameters.Add("@WhoWeAreID", updateWhoWeAreDto.WhoWeAreID);
           
           

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task<GetByIDWhoWeAre> GetWhoWeAreByID(int id)
        {
            string query = "Select * From WhoWeAre Where WhoWeAreID=@whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@WhoWeAreID", id);
            using (var connection = _context.CreateConnection())
            {
                var getID = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAre>(query, parameters); // Sadece bir değer döndürür. Gönderdiğim kategorinin id bilgisi geli. Diğerleri gelmez!

                return getID;
            }

        }
    }
}
