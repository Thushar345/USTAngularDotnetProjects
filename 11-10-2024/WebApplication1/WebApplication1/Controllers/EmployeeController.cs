using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        //Returning just a normal string 
        [HttpGet("Name")]
        public string GetName()
        {
            return "Return from GetName";
        }

        //Returning complex type
        [HttpGet("Details")]
        public Employee GetEmployeeDetails()
        {
            return new Employee()
            {
                Id = 1001,
                Name = "Anurag",
                Age = 28,
                City = "Mumbai",
                Gender = "Male",
                Department = "IT"
            };
        }

        //Returning all the employee in a list
        [HttpGet("All")]
        public IEnumerable<Employee> GetAllEmployee()
        {
            return new List<Employee>()
            {
                new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
                new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
                new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
            };
        }


        [HttpGet("{Id}")]
        public IActionResult GetEmployeeDetails(int Id)
        {
            try
            {
                var listEmployees = new List<Employee>()
                {
                    new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
                    new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
                    new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
                };
               
                var employee = listEmployees.FirstOrDefault(emp => emp.Id == Id);

                if (employee != null)
                {
                    return Ok(employee);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            Employee employee2 = new Employee();

        }

        


    }
}
