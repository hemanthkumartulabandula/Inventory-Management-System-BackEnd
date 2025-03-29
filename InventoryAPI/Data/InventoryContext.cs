using Microsoft.EntityFrameworkCore;
using InventoryAPI.Models;

namespace InventoryAPI.Data;

public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

    public DbSet<Electronic> Electronics { get; set; }
    public DbSet<FoodItem> FoodItems { get; set; }
    public DbSet<SportingGood> SportingGoods { get; set; }
    
}