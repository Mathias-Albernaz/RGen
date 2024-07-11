using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Repositorio;

public class SqlContext : DbContext
{
    public DbSet<Datos> Datos { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<PlantillaRecibo> Type { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Datos>()
            .HasKey(d => d.Id);
        modelBuilder.Entity<Item>()
            .HasKey(i => i.Id);
        modelBuilder.Entity<PlantillaRecibo>()
            .HasKey(r => r.Id);
        modelBuilder.Entity<PlantillaRecibo>()
            .HasOne(r => r.Datos)
            .WithOne()
            .HasForeignKey<Datos>(d => d.Id);
        modelBuilder.Entity<PlantillaRecibo>()
            .HasMany(r => r.Items)
            .WithOne()
            .HasForeignKey(i => i.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"..\UserInterface\Data");
    }
}