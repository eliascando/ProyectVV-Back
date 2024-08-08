namespace Domain.Interfaces
{
    public interface ICreate<T>
    {
        T Insert(T entity);
    }
}
