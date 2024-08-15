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
        modelBuilder.Entity<Dato>()
            .Property(d => d.Id)
            .ValueGeneratedOnAdd(); // Auto-incrementar al agregar

        modelBuilder.Entity<Item>()
            .HasKey(i => i.Id);
        modelBuilder.Entity<Item>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd(); // Auto-incrementar al agregar

        modelBuilder.Entity<Recibo>()
            .HasKey(r => r.Id);
        modelBuilder.Entity<Recibo>()
            .Property(r => r.Id)
            .ValueGeneratedOnAdd(); // Auto-incrementar al agregar
        
        modelBuilder.Entity<Recibo>()
            .HasMany(r => r.Items) // Un Recibo tiene varios Items
            .WithOne(r => r.Recibo) // Un Item tiene un Recibo
            .HasForeignKey(r => r.ReciboId) // Clave foranea a Recibo
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Recibo>()
            .HasOne(r => r.Dato) // Un Recibo tiene un Dato
            .WithOne(d => d.Recibo) // Un Dato tiene un Recibo
            .HasForeignKey<Recibo>(r => r.Id) // La clave foránea en Recibo
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);; 
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=..\UserInterface\Data\RGenDb.db");
    }
}