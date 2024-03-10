using Microsoft.EntityFrameworkCore;
using StudentCRUD.Application;
using StudentCRUD.Domain.Repositories;

namespace StudentCRUD.Infrastructure;

public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
{
    public IStudentRepository StudentRepository { get; private set; }

    public ApplicationUnitOfWork(IStudentRepository studentRepository,
            IApplicationDbContext dbContext) : base((DbContext)dbContext)
    {
        StudentRepository = studentRepository;
    }

}