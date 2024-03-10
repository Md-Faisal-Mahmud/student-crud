using FirstDemo.Domain.Repositories;
using StudentCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRUD.Domain.Repositories
{
    public interface IStudentRepository : IRepositoryBase<Student, Guid>
    {
    }
}
