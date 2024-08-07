using Dominio;

namespace Logica;

public class DatosFactory
{
    public int IdNueva { get; set; } = 1;

    public Datos Crear(string titulo, string autor, string destinatario, DateTime fecha, string observacion)
    {
        Datos datos = new Datos()
        {
            Titulo = titulo,
            Autor = autor,
            Destinatario = destinatario,
            Fecha = fecha,
            Id = IdNueva
        };
        IdNueva++;
        return datos;
    }
}