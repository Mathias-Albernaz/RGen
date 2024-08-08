using Dominio;

namespace Repositorio;

public class DatoRepo : IRepositorio<Dato>
{
    private SqlContext _contexto;

    public DatoRepo(SqlContext contexto)
    {
        _contexto = contexto;
    }
    
    public void Agregar(Dato elemento)
    {
        _contexto.Add(elemento);
    }

    public void Borrar(int id)
    {
        _contexto.Remove(id);
    }

    public List<Dato> Listar()
    {
        return _contexto.Datos.ToList();
    }

    public Dato Buscar(int id)
    {
        return _contexto.Datos.Find(id);
    }
}