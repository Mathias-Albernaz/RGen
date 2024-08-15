using Dominio;

namespace Logica;

public class ItemFactory
{
    public Item Crear(int cantidad, string descripcion, string identificador)
    {
        Item item = new Item()
        {
            Cantidad = cantidad,
            Descripcion = descripcion,
            Identificador = identificador,

        };
        return item;
    }
}