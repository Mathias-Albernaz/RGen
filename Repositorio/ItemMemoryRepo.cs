using Dominio;

namespace Repositorio;

public class ItemMemoryRepo
{
    public List<Item> Items { get; set; }

    public ItemMemoryRepo()
    {
        Items = new List<Item>();
    }

    public void Agregar(int cantidad, string descripcion, string identificador)
    {
        Item nuevoItem = new Item()
        {
            Cantidad = cantidad,
            Descripcion = descripcion,
            Identificador = identificador
        };
        Items.Add(nuevoItem);
    }

    public List<Item> Listar()
    {
        return Items;
    }

    public void Borrar(Item item)
    {
        Items.Remove(item);
    }
}