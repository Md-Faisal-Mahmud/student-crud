using FirstDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using StudentCRUD.Domain.Entities;
using StudentCRUD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRUD.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student, Guid>, IStudentRepository
    {
        public StudentRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
    }
}