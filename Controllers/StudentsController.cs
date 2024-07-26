
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly StudentContext _context;

        public StudentsController(ILogger<StudentsController> logger, StudentContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            _logger.LogInformation("Getting all students.");
            try
            {
                var students = await _context.Students.ToListAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting students: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/students
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            _logger.LogInformation("Adding a new student.");
            try
            {
                if (student == null)
                {
                    return BadRequest("Student is null");
                }

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetStudents), new { id = student.student_id }, student);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the student: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/students/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            _logger.LogInformation("Updating student with ID {Id}.", id);
            try
            {
                if (id != student.student_id)
                {
                    return BadRequest("Student ID mismatch");
                }

                var existingStudent = await _context.Students.FindAsync(id);
                if (existingStudent == null)
                {
                    return NotFound();
                }

                _context.Entry(existingStudent).CurrentValues.SetValues(student);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating the student: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/students/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            _logger.LogInformation("Deleting student with ID {Id}.", id);
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the student: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}



// File: Controllers/StudentsController.cs
/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly StudentContext _context;

        public StudentsController(ILogger<StudentsController> logger, StudentContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            _logger.LogInformation("Getting all students.");
            try
            {
                var students = await _context.Students.ToListAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting students: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            _logger.LogInformation("Adding a new student.");
            try
            {
                if (student == null)
                {
                    return BadRequest("Student is null");
                }

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetStudents), new { id = student.student_id }, student);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the student: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            _logger.LogInformation("Updating student with ID {Id}.", id);
            try
            {
                if (id != student.student_id)
                {
                    return BadRequest("Student ID mismatch");
                }

                var existingStudent = await _context.Students.FindAsync(id);
                if (existingStudent == null)
                {
                    return NotFound();
                }

                _context.Entry(existingStudent).CurrentValues.SetValues(student);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating the student: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            _logger.LogInformation("Deleting student with ID {Id}.", id);
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the student: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
*/