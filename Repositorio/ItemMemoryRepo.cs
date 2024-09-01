using Dominio;

namespace Repositorio;

public class ItemMemoryRepo
{
    public List<Item> Items { get; set; }

    public void Agregar(int cantidad, string descripcion)
    {
        Item nuevoItem = new Item()
        {
            Cantidad = cantidad,
            Descripcion = descripcion,
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