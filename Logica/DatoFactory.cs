using Dominio;

namespace Logica;

public class DatoFactory
{
    

    public Dato Crear(string titulo, string autor, string destinatario, DateTime? fecha, string? observacion)
    {
        Dato dato = new Dato()
        {
            Titulo = titulo,
            Autor = autor,
            Destinatario = destinatario,
            Fecha = fecha,
            Observacion = observacion,
        };
        return dato;
    }
}