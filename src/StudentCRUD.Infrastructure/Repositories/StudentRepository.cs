using FirstDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using StudentCRUD.Domain.Entities;
using StudentCRUD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRUD.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student, Guid>, IStudentRepository
    {
        public StudentRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

        public async Task<(IList<Student> records, int total, int totalDisplay)>
         GetTableDataAsync(string searchTitle, string orderBy, int pageIndex, int pageSize)
        {
            Expression<Func<Student, bool>> expression = null;

            if (!string.IsNullOrWhiteSpace(searchTitle))
            {
                expression = x => x.Name.Contains(searchTitle);
            }

            return await GetDynamicAsync(expression, orderBy, null, pageIndex, pageSize, true);
        }
    }
}