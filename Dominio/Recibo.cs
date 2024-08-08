namespace Dominio;

public class Recibo
{
    public int Id { get; set; }
    public List<Item> Items { get; set; }
    public Dato Dato { get; set; }

    public Recibo()
    {
        List<Item> items = new List<Item>();
    }
    public Recibo(List<Item> items, Dato dato)
    {
        Items = items;
        Dato = dato;
    }
}