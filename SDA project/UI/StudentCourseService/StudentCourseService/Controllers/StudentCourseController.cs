using Microsoft.AspNetCore.Mvc;
using StudentCourseService.Data;
using StudentCourseService.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentCourseService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentCourseController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public StudentCourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET all student-course relations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentCourse>>> GetAll()
        {
            return await _context.StudentCourses.ToListAsync();
        }

        [HttpGet("assigned")]
        public async Task<ActionResult<IEnumerable<object>>> GetAllAssignments()
        {
            var data = await _context.StudentCourses
            .Include(sc => sc.Student)
            .Include(sc => sc.Course)
            .Select(sc => new {
                StudentName = sc.Student.Name,
                CourseTitle = sc.Course.Title
            }).ToListAsync();

            return Ok(data);
        }

        // GET by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentCourse>> GetById(int id)
        {
            var sc = await _context.StudentCourses.FindAsync(id);
            if (sc == null)
                return NotFound();

            return sc;
        }

        // POST: Add new relation
        [HttpPost]
        public async Task<ActionResult<StudentCourse>> AddRelation(StudentCourse sc)
        {
            _context.StudentCourses.Add(sc);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = sc.Id }, sc);
        }

        // DELETE: Remove a relation
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sc = await _context.StudentCourses.FindAsync(id);
            if (sc == null)
                return NotFound();

            _context.StudentCourses.Remove(sc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
