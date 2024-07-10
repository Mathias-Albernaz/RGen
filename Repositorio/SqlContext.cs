using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class SqlContext : DbContext
{
    public DbSet<Recibo> Recibos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}