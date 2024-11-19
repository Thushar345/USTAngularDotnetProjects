using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> _student = new List<Student>
        {
            new Student { Id = 1, Name = "Aparna", Place = "Palakkad", Marks = 34 },
            new Student { Id = 2, Name = "Aman", Place = "Mannarkkad", Marks = 35 },
            new Student { Id = 3, Name = "Rithin", Place = "Alapuzha", Marks = 26 },
            
        };
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents() {
            return _student;
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _student.FirstOrDefault(s => s.Id == id);
            if (student == null){
                return NotFound();
            }
            return student;
        }
        [HttpPost]
        public ActionResult<Student> PostProduct(Student student)
        {
            _student.Add(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _student.FirstOrDefault(p => p.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            _student.Remove(student);
            return NoContent();
        }

    }
}
