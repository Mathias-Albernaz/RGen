namespace Repository;
using Dominio;

public class ItemRepo
{
    public List<Item> Items { get; set; }

    public ItemRepo()
    {
        Items = new List<Item>();
    }

    public void addItem(int cantidad, string descripcion, string id)
    {
        if (!Items.Exists(i => i.Identificador == id))
        {
            Item newItem = new Item()
            {
                Cantidad = cantidad,
                Descripcion = descripcion,
                Identificador = id
            };
            Items.Add(newItem);
        }
    }

    public List<Item> listItems()
    {
        return Items;
    }
    
}