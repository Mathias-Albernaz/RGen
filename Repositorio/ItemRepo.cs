using Dominio;

namespace Repositorio;

public class ItemRepo : IRepositorio<Item>
{
    private SqlContext _contexto;

    public ItemRepo(SqlContext contexto)
    {
        _contexto = contexto;
    }
    
    public Item Agregar(Item elemento)
    {
        _contexto.Add(elemento);
        _contexto.SaveChanges();
        return elemento;
    }
    
    public void Borrar(int id)
    {
        if (_contexto.Items.Find(id) != null)
        {
            _contexto.Remove(id);
            _contexto.SaveChanges();
        }
    }

    public List<Item> Listar()
    {
        return _contexto.Items.ToList();
    }

    public Item Buscar(int id)
    {
        return _contexto.Items.Find(id);
    }
}