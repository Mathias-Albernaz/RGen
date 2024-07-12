using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Repositorio;

public class SqlContext : DbContext
{
    public DbSet<Recibo> Recibos { get; set; }
    public DbSet<Datos> Datos { get; set; }
    public DbSet<Item> Item { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Datos>()
            .HasKey(d => d.Id);
        modelBuilder.Entity<Item>()
            .HasKey(i => i.Id);
        modelBuilder.Entity<Recibo>()
            .HasKey(r => r.Id);
        modelBuilder.Entity<Recibo>()
            .HasOne(r => r.Datos)
            .WithOne()
            .HasForeignKey<Datos>(d => d.Id);
        modelBuilder.Entity<Recibo>()
            .HasMany(r => r.Items)
            .WithMany();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=..\UserInterface\Data\RGenDb.db");
    }
}