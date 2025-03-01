using RealEstate_2_API.Models.D_Context;
using RealEstate_2_API.Repositories.AgentRepositories;
using RealEstate_2_API.Repositories.CategoryRepositories;
using RealEstate_2_API.Repositories.CustomerRepositories;
using RealEstate_2_API.Repositories.FeatureRepositories;
using RealEstate_2_API.Repositories.ProductRepositories;
using RealEstate_2_API.Repositories.WhoWeAreRepositories;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();
builder.Services.AddTransient<IProductRepo, ProductRepo>();
builder.Services.AddTransient<IFeatureRepo, FeatureRepo>();
builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();
builder.Services.AddTransient<IWhoWeAreRepo, WhoWeAreRepo>();
builder.Services.AddTransient<IAgentRepo, AgentRepo>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
