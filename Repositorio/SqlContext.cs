using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Repositorio;

public class SqlContext : DbContext
{
    public DbSet<Recibo> Recibos { get; set; }
    public DbSet<Dato> Datos { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dato>()
            .HasKey(d => d.Id);
        modelBuilder.Entity<Item>()
            .HasKey(i => i.Id);
        modelBuilder.Entity<Recibo>()
            .HasMany(r => r.Items)
            .WithOne(r => r.Recibo)
            .HasForeignKey(r => r.ReciboId)
            .IsRequired(false);
        modelBuilder.Entity<Recibo>()
            .HasOne(r => r.Dato) // Un Recibo tiene un Dato
            .WithOne(d => d.Recibo) // Un Dato tiene un Recibo
            .HasForeignKey<Recibo>(r => r.Id) // La clave foránea en Recibo
            .OnDelete(DeleteBehavior.Restrict); 
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=..\UserInterface\Data\RGenDb.db");
    }
}