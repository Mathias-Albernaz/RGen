namespace Dominio;

public class Dato
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Destinatario { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Observacion { get; set; }
    
    //propiedad de navegacion
    public Recibo Recibo { get; set; }
}