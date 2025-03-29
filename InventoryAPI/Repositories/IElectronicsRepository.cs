using InventoryAPI.Models;

namespace InventoryAPI.Repositories;

public interface IElectronicsRepository
{
    Task<IEnumerable<Electronic>> GetAllAsync();
    Task<Electronic?> GetByIdAsync(int id);
    Task<Electronic> AddAsync(Electronic item);
    Task<bool> UpdateAsync(Electronic item);
    Task<bool> DeleteAsync(int id);
}