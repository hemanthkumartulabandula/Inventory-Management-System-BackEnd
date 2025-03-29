using InventoryAPI.Models;

namespace InventoryAPI.Repositories;

public interface IFoodItemsRepository
{
    Task<IEnumerable<FoodItem>> GetAllAsync();
    Task<FoodItem?> GetByIdAsync(int id);
    Task<FoodItem> AddAsync(FoodItem item);
    Task<bool> UpdateAsync(FoodItem item);
    Task<bool> DeleteAsync(int id);
}