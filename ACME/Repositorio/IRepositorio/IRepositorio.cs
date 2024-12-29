namespace ACME.Repositorio.IRepositorio
{

    public interface IRepositorio<T> where T : class
    {
        Task<T> Obtener();
        Task Crear(T entidad);
        Task Eliminar(T entidad);
        Task Guardar();
        Task ObtenerTodos();

    }
}
