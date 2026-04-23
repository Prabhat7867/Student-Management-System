using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS_API.Data;
using SMS_API.Services;

namespace SMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentServices services;
        public StudentController(Services.StudentServices _services)
        {
            services = _services;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var student = await services.GetStudents();
            return Ok(student);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await services.GetStudentbyId(id);
            if (student == null) { return NotFound(); }

            return Ok(student);

        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student std)
        {
            if (std == null) { return BadRequest("Student can not be null"); }

            if (string.IsNullOrWhiteSpace(std.Name)) { return BadRequest("Name is required"); }

            return await services.AddStudent(std);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            if (std == null) { return BadRequest("Student can not be null"); }

            if (id != std.Id)
                return BadRequest("Id mismatch");

            if (string.IsNullOrWhiteSpace(std.Name))
                return BadRequest("Name is required");

            var updated = await services.UpdateStudent(std);

            if (updated == null)
                return NotFound();

            return Ok(updated);

        }

        [HttpDelete]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {

            var deleted = await services.DeleteStudent(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);

        }

    }
}
