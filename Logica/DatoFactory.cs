using Dominio;

namespace Logica;

public class DatoFactory
{
    public int IdNueva { get; set; } = 1;

    public Dato Crear(string titulo, string autor, string destinatario, DateTime fecha, string observacion)
    {
        Dato dato = new Dato()
        {
            Titulo = titulo,
            Autor = autor,
            Destinatario = destinatario,
            Fecha = fecha,
            Id = IdNueva
        };
        IdNueva++;
        return dato;
    }
}