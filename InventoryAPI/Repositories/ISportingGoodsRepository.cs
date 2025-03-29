using InventoryAPI.Models;

namespace InventoryAPI.Repositories;

public interface ISportingGoodsRepository
{
    Task<IEnumerable<SportingGood>> GetAllAsync();
    Task<SportingGood?> GetByIdAsync(int id);
    Task<SportingGood> AddAsync(SportingGood item);
    Task<bool> UpdateAsync(SportingGood item);
    Task<bool> DeleteAsync(int id);
}