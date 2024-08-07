using Dominio;

namespace Repositorio;

public class ItemRepo : IRepositorio<Item>
{
    private SqlContext _contexto;

    public ItemRepo(SqlContext contexto)
    {
        _contexto = contexto;
    }
    
    public void Agregar(Item elemento)
    {
        _contexto.Add(elemento);
    }
    
    public void Borrar(int id)
    {
        if (_contexto.Items.Find(id) != null)
        {
            _contexto.Remove(id);
        }
    }

    public List<Item> Listar()
    {
        return _contexto.Items.ToList();
    }
    
}