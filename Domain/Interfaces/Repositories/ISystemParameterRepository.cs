namespace Domain.Interfaces.Repositories
{
    public interface ISystemParameterRepository<T, TDetails>
    {
        List<T> GetAll();  
        T GetById(long id);
        TDetails GetByDetailId(long id);
        T RegisterNew(T entity);
        List<T> ObtenerDropDownsPorEstudiante(long idUser, long idCurso);
    }
}
