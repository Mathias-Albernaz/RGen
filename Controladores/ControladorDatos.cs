using Dominio;
using Logica;
using Repositorio;

namespace Controladores;

public class ControladorDatos
{
   private readonly IRepositorio<Dato> _repositorio;
   private DatoFactory _datoFactory;

   public ControladorDatos(IRepositorio<Dato> repositorioDatos, DatoFactory datoFactory)
   {
      _repositorio = repositorioDatos;
      _datoFactory = datoFactory;
   }

   public Dato AgregarDatos(string titulo, string autor, string destinatario, DateTime? fecha, string observacion)
   {
      Dato nuevoDato = _datoFactory.Crear(titulo, autor, destinatario, fecha, observacion);
      return _repositorio.Agregar(nuevoDato);
   }

   public void BorrarDatos(int id)
   {
      _repositorio.Borrar(id);
   }

   public List<Dato> ListarDatos()
   {
      return _repositorio.Listar();
   }

   public Dato BuscarDato(int id)
   {
      return _repositorio.Buscar(id);
   }
}