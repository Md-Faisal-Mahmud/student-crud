namespace StudentCRUD.Domain.UnitOfWorks;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    void Save();
    Task SaveAsync();
}