using Dominio;
using Logica;
using Repositorio;

namespace Controladores;

public class ControladorRecibos
{
    private readonly IRepositorio<Recibo> _repositorio;
    private ReciboFactory _reciboFactory;

    public ControladorRecibos(IRepositorio<Recibo> repositorioRecibo, ReciboFactory reciboFactory)
    {
        _repositorio = repositorioRecibo;
        _reciboFactory = reciboFactory;
    }

    public void AgregarRecibo(Dato dato, List<Item> items)
    {
        Recibo nuevoRecibo = _reciboFactory.Crear(items, dato);
        _repositorio.Agregar(nuevoRecibo);
    }

    public void BorrarRecibo(int id)
    {
        _repositorio.Borrar(id);
    }

    public List<Recibo> ListarRecibos()
    {
        return _repositorio.Listar();
    }

    public Recibo BuscarRecibo(int id)
    {
        return _repositorio.Buscar(id);
    }
}