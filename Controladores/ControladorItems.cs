using Dominio;
using Logica;
using Repositorio;

namespace Controladores;

public class ControladorItems
{
    private readonly IRepositorio<Item> _repositorio;
    private ItemFactory _itemFactory;

    public ControladorItems(IRepositorio<Item> repositorioItems, ItemFactory itemFactory)
    {
        _repositorio = repositorioItems;
        _itemFactory = itemFactory;
    }

    public Item AgregarItem(int cantidad, string descripcion, string identificador)
    {
        Item nuevoItem = _itemFactory.Crear(cantidad, descripcion, identificador);
        return _repositorio.Agregar(nuevoItem);
    }

    public void BorrarItem(int id)
    {
        _repositorio.Borrar(id);
    }

    public List<Item> ListarItems()
    {
        return _repositorio.Listar();
    }

    public Item BuscarItem(int id)
    {
        return _repositorio.Buscar(id);
    }
}