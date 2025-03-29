using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Repositories;

public class SportingGoodsRepository : ISportingGoodsRepository
{
    private readonly InventoryContext _context;

    public SportingGoodsRepository(InventoryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SportingGood>> GetAllAsync() =>
        await _context.SportingGoods.ToListAsync();

    public async Task<SportingGood?> GetByIdAsync(int id) =>
        await _context.SportingGoods.FindAsync(id);

    public async Task<SportingGood> AddAsync(SportingGood item)
    {
        _context.SportingGoods.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<bool> UpdateAsync(SportingGood item)
    {
        if (!await _context.SportingGoods.AnyAsync(e => e.Id == item.Id))
            return false;

        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.SportingGoods.FindAsync(id);
        if (item == null) return false;

        _context.SportingGoods.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }
}