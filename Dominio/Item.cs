namespace Dominio;

public class Item
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public string Descripcion { get; set; }
    public string? Identificador { get; set; }
    
    //Propiedades de navegacion
    public Recibo? Recibo { get; set; }
    public int ReciboId { get; set; }
    

    public override string ToString()
    {
        return Cantidad + "," + Descripcion + "," + Identificador;
    }
}