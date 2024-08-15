namespace Dominio;

public class Recibo
{
    public int Id { get; set; }
    
    public ICollection<Item> Items { get; set; } = new List<Item>();

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