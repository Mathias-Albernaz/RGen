namespace Repositorio;

public interface IRepositorio<T>
{
    void Agregar(T elemento);
    void Borrar(int id);
    List<T> Listar();
    T Buscar(int id);
}   
    