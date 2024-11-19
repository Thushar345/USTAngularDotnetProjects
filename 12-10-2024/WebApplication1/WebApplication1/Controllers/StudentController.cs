using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)
        {
            return Ok(_studentService.GetAllStudents(isActive));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var hero = _studentService.GetStudentByID(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public IActionResult Post(AddUpdateStudent heroObject)
        {
            var hero = _studentService.AddStudent(heroObject);

            if (hero == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Super Hero Created Successfully!!!",
                id = hero!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AddUpdateStudent heroObject)
        {
            var hero = _studentService.UpdateStudent(id, heroObject);
            if (hero == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Updated Successfully!!!",
                id = hero!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_studentService.DeleteStudentID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Deleted Successfully!!!",
                id = id
            });
        }
    }
}
