using Microsoft.EntityFrameworkCore;
using StudentCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRUD.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; }
    }
}
