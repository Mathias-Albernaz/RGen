using Dominio;

namespace Repositorio;

public class DatoRepo : IRepositorio<Datos>
{
    private SqlContext _contexto;

    public DatoRepo(SqlContext contexto)
    {
        _contexto = contexto;
    }
    
    public void Agregar(Datos elemento)
    {
        _contexto.Add(elemento);
    }

    public void Borrar(int id)
    {
        _contexto.Remove(id);
    }

    public List<Datos> Listar()
    {
        return _contexto.Datos.ToList();
    }
}