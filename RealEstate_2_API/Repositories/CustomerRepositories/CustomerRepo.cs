using Dapper;
using Microsoft.AspNetCore.Authentication;
using RealEstate_2_API.Dtos.CustomerDtos;
using RealEstate_2_API.Models.D_Context;

namespace RealEstate_2_API.Repositories.CustomerRepositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly Context _context;

        public CustomerRepo(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultCustomerDto>> GetListCustomerAsync()
        {
            string query = "select * from Client";
            using(var cnt = _context.CreateConnection())
            {
                var values = await cnt.QueryAsync<ResultCustomerDto>(query);
                return values.ToList();
            }
           
        }
    }
}
