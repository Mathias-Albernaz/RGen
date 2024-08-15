using Dominio;

namespace Repositorio;

public class ItemRepo : IRepositorio<Item>
{
    private SqlContext _contexto;

    public ItemRepo(SqlContext contexto)
    {
        _contexto = contexto;
    }
    
    public bool TestConexion()
    {
        try
        {
            // Ejecuta una consulta simple
            var canConnect = _contexto.Database.CanConnect();
            return canConnect;
        }
        catch (Exception ex)
        {
            // Maneja y registra la excepción
            Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            return false;
        }
    }
    
    public Item Agregar(Item elemento)
    {
        TestConexion();
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