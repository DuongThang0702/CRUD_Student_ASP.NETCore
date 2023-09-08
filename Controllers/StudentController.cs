using CRUD_Asp.Models.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _studentContext;
        public StudentController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            if (_studentContext.Students == null)
            {
                return NotFound();
            }

            return await _studentContext.Students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _studentContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student payload)
        {
            _studentContext.Students.Add(payload);
            await _studentContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentById), new { id = payload.Id }, payload);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> ModifyStudent(int id, Student payload)
        {
            if (id != payload.Id)
            {
                return BadRequest();
            }

            _studentContext.Entry(payload).State = EntityState.Modified;
            try
            {
                await _studentContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) { throw; }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await _studentContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentContext.Students.Remove(student);
            await _studentContext.SaveChangesAsync();

            return Ok();
        }
    }
}
