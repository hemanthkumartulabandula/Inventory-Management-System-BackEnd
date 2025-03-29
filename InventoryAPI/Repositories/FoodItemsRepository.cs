using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Repositories;

public class FoodItemsRepository : IFoodItemsRepository
{
    private readonly InventoryContext _context;

    public FoodItemsRepository(InventoryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FoodItem>> GetAllAsync() =>
        await _context.FoodItems.ToListAsync();

    public async Task<FoodItem?> GetByIdAsync(int id) =>
        await _context.FoodItems.FindAsync(id);

    public async Task<FoodItem> AddAsync(FoodItem item)
    {
        _context.FoodItems.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<bool> UpdateAsync(FoodItem item)
    {
        if (!await _context.FoodItems.AnyAsync(e => e.Id == item.Id))
            return false;

        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.FoodItems.FindAsync(id);
        if (item == null) return false;

        _context.FoodItems.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }
}