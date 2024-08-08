namespace Domain.Interfaces
{
    public interface IUpdate<T>
    {
        T Update(long id, T entity);
    }
}
