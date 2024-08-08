using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Repositorio;

public class ReciboRepo : IRepositorio<Recibo>
{
    private SqlContext _contexto;

    public ReciboRepo(SqlContext contexto)
    {
        _contexto = contexto;
    }
    
    public void Agregar(Recibo elemento)
    {
        _contexto.Add(elemento);
    }

    public void Borrar(int id)
    {
        _contexto.Remove(id);
    }

    public List<Recibo> Listar()
    {
        return _contexto.Recibos.Include(recibo => recibo.Items)
            .Include(recibo => recibo.Dato)
            .ToList();
    }

    public Recibo Buscar(int id)
    {
        return _contexto.Recibos.Find(id);
    }
}