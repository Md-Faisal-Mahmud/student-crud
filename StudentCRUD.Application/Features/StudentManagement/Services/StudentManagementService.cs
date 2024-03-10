using StudentCRUD.Domain.Entities;
using StudentCRUD.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRUD.Application.Features.StudentManagement.Services
{
    public class StudentManagementService : IStudentManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public StudentManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddStudentAsync(Student student)
        {
            await _unitOfWork.StudentRepository.AddAsync(student);
            await _unitOfWork.SaveAsync();
        }

        public Task DeleteStudentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Student>> GetStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
