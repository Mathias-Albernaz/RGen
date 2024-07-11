using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Repositorio;

public class SqlContext : DbContext
{
    public DbSet<Recibo> Recibos { get; set; }

    
}