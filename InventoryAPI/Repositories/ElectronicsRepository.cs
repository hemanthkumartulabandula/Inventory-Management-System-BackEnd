using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Repositories;

public class ElectronicsRepository : IElectronicsRepository
{
    private readonly InventoryContext _context;

    public ElectronicsRepository(InventoryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Electronic>> GetAllAsync() =>
        await _context.Electronics.ToListAsync();

    public async Task<Electronic?> GetByIdAsync(int id) =>
        await _context.Electronics.FindAsync(id);

    public async Task<Electronic> AddAsync(Electronic item)
    {
        _context.Electronics.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<bool> UpdateAsync(Electronic item)
    {
        if (!await _context.Electronics.AnyAsync(e => e.Id == item.Id))
            return false;

        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.Electronics.FindAsync(id);
        if (item == null) return false;

        _context.Electronics.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }
}