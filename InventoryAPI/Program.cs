using InventoryAPI.Data;
using InventoryAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IElectronicsRepository, ElectronicsRepository>();
builder.Services.AddScoped<IFoodItemsRepository, FoodItemsRepository>();
builder.Services.AddScoped<ISportingGoodsRepository, SportingGoodsRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory API V1");
    c.RoutePrefix = ""; // Swagger loads at root URL
});


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();