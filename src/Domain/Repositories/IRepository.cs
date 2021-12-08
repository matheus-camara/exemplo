namespace Domain.Repositories;

public interface IRepository<T>
{
    void AddOrUpdate(T item);
    Task SaveAsync();
}