using Autofac;
using StudentCRUD.Application.Features.StudentManagement.Services;
using StudentCRUD.Domain.Entities;
using StudentCRUD.Infrastructure.Utilites;
using System.Web;

namespace StudentCRUD.Api.RequestHandlers.StudentHandler;

public class StudentListRequestHandler
{
    private ILifetimeScope _scope;
    private IStudentManagementService _studentManagementService;

    public StudentSearch SearchItem { get; set; }

    public StudentListRequestHandler()
    {
    }

    public StudentListRequestHandler(IStudentManagementService studentManagementService)
    {
        _studentManagementService = studentManagementService;
    }

    public void Resolve(ILifetimeScope scope)
    {
        _scope = scope;
        _studentManagementService = _scope.Resolve<IStudentManagementService>();
    }

    public async Task<object?> GetPagedStudentsAsync(DataTablesAjaxRequestUtility dataTablesUtility)
    {
        var data = await _studentManagementService.GetPagedStudentsAsync(
            dataTablesUtility.PageIndex,
            dataTablesUtility.PageSize,
            dataTablesUtility.SearchText,
            dataTablesUtility.GetSortText(new string[] {"Image", "Name", "Age", "FatherName", "MotherName" }));

        return new
        {
            recordsTotal = data.total,
            recordsFiltered = data.totalDisplay,
            data = (from record in data.records
                    select new string[]
                    {
                        HttpUtility.HtmlEncode(record.Image),
                        HttpUtility.HtmlEncode(record.Name),
                        record.Age.ToString(),
                        HttpUtility.HtmlEncode(record.FatherName),
                        HttpUtility.HtmlEncode(record.MotherName),
                        record.Id.ToString()
                    }
                    ).ToArray()
        };
    }

    public async Task<IList<Student>>? GetStudentsAsync()
    {
        return await _studentManagementService?.GetStudentsAsync();
    }
}
