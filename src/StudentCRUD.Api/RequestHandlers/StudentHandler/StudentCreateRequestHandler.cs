using Autofac;
using StudentCRUD.Application.Features.StudentManagement.Services;
using StudentCRUD.Domain.Entities;
using StudentCRUD.Infrastructure;

namespace StudentCRUD.Api.RequestHandlers.StudentHandler
{
    public class StudentCreateRequestHandler
    {
        private IStudentManagementService _studentManagementService;

        public byte[]? Image { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }


        public StudentCreateRequestHandler() { }

        public StudentCreateRequestHandler(IStudentManagementService studentManagementService)
        {
            _studentManagementService = studentManagementService;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _studentManagementService = scope.Resolve<IStudentManagementService>();
        }
        
        public async Task AddStudentAsync()
        {
            var student = new Student()
            {
                Image = Image,
                Name = Name,
                Age = Age,
                FatherName = FatherName,
                MotherName = MotherName
            };

            await _studentManagementService.AddStudentAsync(student);
        }
    }
}
