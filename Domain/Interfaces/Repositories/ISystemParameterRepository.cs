namespace Domain.Interfaces.Repositories
{
    public interface ISystemParameterRepository<T, TDetails>
    {
        List<T> GetAll();  
        T GetById(long id);
        T RegisterNew(T entity);
    }
}
