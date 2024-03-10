using StudentCRUD.Domain.Entities;
using StudentCRUD.Domain.UnitOfWorks;
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
        Task<(IList<Student> records, int total, int totalDisplay)>GetPagedStudentsAsync
            (int pageIndex, int pageSize, string searchTitle, string sortBy);
        Task<IList<Student>>? GetStudentsAsync();

    }
}
