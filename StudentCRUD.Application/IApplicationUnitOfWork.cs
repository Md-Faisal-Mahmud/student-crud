using StudentCRUD.Domain.Repositories;
using StudentCRUD.Domain.UnitOfWorks;

namespace StudentCRUD.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
    }
}