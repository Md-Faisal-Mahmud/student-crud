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

        public async Task<IList<Student>>? GetStudentsAsync()
        {
            return await _unitOfWork.StudentRepository.GetAllAsync();
        }

        public async Task<(IList<Student> records, int total, int totalDisplay)>
            GetPagedStudentsAsync(int pageIndex, int pageSize, string searchTitle, string sortBy)
        {
            return await _unitOfWork.StudentRepository.GetTableDataAsync(searchTitle, sortBy, pageIndex, pageSize);
        }

        public Task UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
