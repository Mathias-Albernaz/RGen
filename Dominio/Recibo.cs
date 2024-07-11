namespace Dominio;

public class Recibo
{
    public int Id { get; set; }
    public List<Item> Items { get; set; }
    public Datos Datos { get; set; }

    public Recibo()
    {
        List<Item> items = new List<Item>();
    }
    public Recibo(List<Item> items, Datos datos)
    {
        Items = items;
        Datos = datos;
    }
}