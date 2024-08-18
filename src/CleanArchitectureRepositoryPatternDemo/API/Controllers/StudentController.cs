using Application.Common.Student;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(StudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents(CancellationToken cancellationToken)
        {
            return Ok(await _studentService.GetStudentsAsync(cancellationToken));
        }

        [HttpGet("{studentNo}")]
        public async Task<IActionResult> GetByStudentNo(string studentNo, CancellationToken cancellationToken)
        {
            var result = await _studentService.FindByStudentNo(studentNo, cancellationToken);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest createStudentRequest, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stud = await _studentService.CreateStudentAsync(createStudentRequest, cancellationToken);
            if (stud is null)
            {
                return BadRequest();
            }

            return Ok(stud.Id);
        }
    }
}