using StudentCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRUD.Application.Features.StudentManagement.Services
{
    public interface IStudentManagementService
    {
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Guid id);
        Task<ICollection<Student>> GetStudentsAsync(); 

    }
}
