using controle_estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace controle_estoque.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Production> Productions {get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=stock-control.db;Cache=Shared");
}