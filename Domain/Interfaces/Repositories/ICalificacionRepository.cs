namespace Domain.Interfaces.Repositories
{
    public interface ICalificacionRepository<T, TNewDto> : IRepositoryBase<T> 
    {
        IEnumerable<T> ObtenerPorUsuarioyCurso(long user, long curso);
        IEnumerable<T> ObtenerPorMatricula(long matricula);
        IEnumerable<T> ObtenerPromediosPorMatricula(long matricula);
    }
}
