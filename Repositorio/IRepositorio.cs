using Dominio;

namespace Repositorio;

public interface IRepositorio<T>
{
    T Agregar(T elemento);
    void Borrar(int id);
    List<T> Listar();
    T Buscar(int id);
}   
    