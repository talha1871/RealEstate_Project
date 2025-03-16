using Dapper;
using RealEstate_2_API.Dtos.AgentDtos;
using RealEstate_2_API.Dtos.EmployeeDtos;
using RealEstate_2_API.Models.D_Context;

namespace RealEstate_2_API.Repositories.AgentRepositories
{
    public class AgentRepo : IAgentRepo
    {

        // Employee Kısmı
        private readonly Context _context;

        public AgentRepo(Context context)
        {
            _context = context;
        }

        

        public async Task<List<ResultAgentDto>> GetListAgent()
        {
            string query = "select * from Employee";
            using (var cnt = _context.CreateConnection())
            {
                var value = await cnt.QueryAsync<ResultAgentDto>(query);
                return value.ToList();
            }
        }
        public async void CreateAgent(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Employee (Name, Title, Mail, PhoneNumber, ImageURL, Description, Status) values (@name, @title, @mail, @phonenumber, @imageurl, @description, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createEmployeeDto.Name);
            parameters.Add("@title", createEmployeeDto.Title);
            parameters.Add("@mail", createEmployeeDto.Mail);
            parameters.Add("@phoneNumber", createEmployeeDto.PhoneNumber);
            parameters.Add("@imageURL", createEmployeeDto.ImageURL);
            parameters.Add("@descripton", createEmployeeDto.Description);
            parameters.Add("@status", true);

            using (var cnt = _context.CreateConnection())
            {
                await cnt.ExecuteAsync(query, parameters);

            }
        }

        public async void DeleteAgent(int id)
        {
            string query = "delete from Employee Where EmployeeID=@employeeyID";
            var parameter = new DynamicParameters();
            parameter.Add("@employeeID",id);
            using (var cnt = _context.CreateConnection())
            {
                await cnt.ExecuteAsync(query, parameter);
            }
        }

        public async void UpdateAgent(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "Update Employee Set Name=@name, Title=@title, Mail=@mail, PhoneNumber=@phoneNumber, ImageURL = @imageURL, Description=@description, Status=@status where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateEmployeeDto.Name);
            parameters.Add("@title", updateEmployeeDto.Title);
            parameters.Add("@mail", updateEmployeeDto.Mail);
            parameters.Add("@phoneNumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("@imageURL", updateEmployeeDto.ImageURL);
            parameters.Add("@description", updateEmployeeDto.Description);
            parameters.Add("@status", updateEmployeeDto.Status);
            parameters.Add("@name", updateEmployeeDto.Name);
            using (var cnt = _context.CreateConnection())
            {
                await cnt.ExecuteAsync(query, parameters);
            }
        
        }
    }
}
