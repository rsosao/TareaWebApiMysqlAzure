using ApiAzureTarea2.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAzureTarea2;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Libro> Libros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.ToTable("libros");
            entity.HasIndex(e => e.Isbn).IsUnique();
        });
    }
}
