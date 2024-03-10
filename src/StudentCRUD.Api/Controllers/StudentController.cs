using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCRUD.Api.RequestHandlers.StudentHandler;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreateRequestHandler request)
        {
            try
            {
                request.ResolveDependency(_scope);
                await request.AddStudentAsync();

                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(500, "Oops! Something went wrong. Please try again later.");
            }
        }
    }
}
