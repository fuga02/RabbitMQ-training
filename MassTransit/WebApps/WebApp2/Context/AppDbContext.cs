using Filed.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApp2.Context;

public class AppDbContext:DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=users1.db");
    }
}