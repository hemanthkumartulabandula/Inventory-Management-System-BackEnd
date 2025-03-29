using InventoryAPI.Data;
using InventoryAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Read connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ✅ Register DbContext with SQLite
builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlite(connectionString));

// ✅ Register Repositories for DI
builder.Services.AddScoped<IElectronicsRepository, ElectronicsRepository>();
builder.Services.AddScoped<IFoodItemsRepository, FoodItemsRepository>();
builder.Services.AddScoped<ISportingGoodsRepository, SportingGoodsRepository>();

// ✅ Add controllers and Swagger services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Use Swagger in all environments (dev & prod)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory API V1");
    c.RoutePrefix = ""; // Swagger loads at root URL
});

// ✅ Default middlewares
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();