namespace Domain.Interfaces
{
    public interface IRead<T>
    {
        List<T> GetAll();
        T GetById(long id);
    }
}
