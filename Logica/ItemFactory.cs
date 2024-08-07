using Dominio;

namespace Logica;

public class ItemFactory
{
    public int IdNueva { get; set; } = 1;

    public Item Crear(int cantidad, string descripcion, string identificador)
    {
        Item item = new Item()
        {
            Cantidad = cantidad,
            Descripcion = descripcion,
            Identificador = identificador,
            Id = IdNueva
        };
        IdNueva++;
        return item;
    }
}