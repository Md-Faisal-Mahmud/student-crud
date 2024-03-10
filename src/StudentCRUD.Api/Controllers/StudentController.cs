using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCRUD.Api.RequestHandlers.StudentHandler;
using StudentCRUD.Infrastructure.Utilites;

namespace StudentCRUD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        [HttpGet]
        public async Task<IActionResult> Get(StudentListRequestHandler request)
        {
            try
            {
                request.Resolve(_scope);
                var students = await request.GetStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Oops! Something went wrong. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreateRequestHandler request)
        {
            try
            {
                request.ResolveDependency(_scope);
                await request.AddStudentAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(500, "Oops! Something went wrong. Please try again later.");
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Get([FromBody] StudentListRequestHandler request)
        //{
        //    try
        //    {
        //        var dataTablesModel = new DataTablesAjaxRequestUtility(Request);
        //        request.Resolve(_scope);
        //        var data = await request.GetPagedStudentsAsync(dataTablesModel);

        //        return new JsonResult(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);

        //        return StatusCode(500, "Oops! Something went wrong. Please try again later.");
        //    }
        //}
    }
}
