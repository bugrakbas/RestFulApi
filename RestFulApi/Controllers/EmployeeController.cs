using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestFulApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestFulApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> EmployeeList = new List<Employee>()
        {
            new Employee
            {
                Id = 1,
                FirstName = "Buğrahan",
                SurName = "Akbaş",
                Email = "bugrahanakbs@gmail.com",
                Gender = "Male",
                BegınDate = new DateTime(2022,05,6),
                Age = 25
            },
            new Employee
            {
                Id=2,
                FirstName = "Mehmet",
                SurName = "Çelik",
                Email = "mehmetcelik@gmail.com",
                Gender = "Male",
                BegınDate = DateTime.Now,
                Age = 23

            } ,
            new Employee
            {
                Id=3,
                FirstName = "Ayşe",
                SurName = "Çelik",
                Email = "aysecelik@gmail.com",
                Gender = "Female",
                BegınDate = DateTime.Now,
                Age = 24
            },
            new Employee
            {
                Id=3,
                FirstName = "Ahmet",
                SurName = "Çakmak",
                Email = "ahmetcakmak@gmail.com",
                Gender = "Female",
                BegınDate = DateTime.Now,
                Age = 21
            },
        };
        /// <summary>
        /// Listing all employees and sorting by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            var employeeList = EmployeeList.OrderBy(x => x.Id).ToList<Employee>();
            return employeeList;
        }

        /// <summary>
        /// FromRoute
        /// Get emplooyes by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = EmployeeList.Where(x => x.Id.Equals(id));
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }
        /// <summary>
        /// FromQuery Example
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEmployeeById([FromQuery] int id)
        {
            var employee = EmployeeList.Where(x => x.Id.Equals(id));
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }
        /// <summary>
        /// Post-Add
        /// FromBody Example
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var _employee = EmployeeList.SingleOrDefault(x => x.Id.Equals(employee.Id));
            if (_employee is not null)
            {
                return BadRequest();
            }
            EmployeeList.Add(employee);
            return Ok();
        }
        /// <summary>
        /// Put-Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            var emplooyes = EmployeeList.SingleOrDefault(x => x.Id.Equals(id));
            if (emplooyes == null)
                return BadRequest();
            return Ok();
        }
        /// <summary>
        /// Delete 
        /// FromRoute Example
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = EmployeeList.SingleOrDefault(x => x.Id.Equals(id));
            if (emp == null)
                return BadRequest();
            EmployeeList.Remove(emp);
            return Ok();
        }
        /// <summary>
        /// Patch example
        /// </summary>
        /// <param name="id"></param>
        /// <param name="emp"></param>
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] JsonPatchDocument<EmployeeDto> emp)
        {
            var employee = new EmployeeDto();
            employee.Email = "deneme@deneme.com";
            emp.ApplyTo(employee);
        }
        /// <summary>
        /// Bonus
        /// Listing the gender field male ones
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public List<Employee> ListEmployee([FromQuery] string gender)
        {
            List<Employee> employees = EmployeeList.Where(x => x.Gender.Equals(gender)).ToList();
            return employees;

        }
        /// <summary>
        /// Bonus
        /// Sorting employees by Age
        /// </summary>
        /// <returns></returns>
        [HttpGet("sort")]
        public List<Employee> SortEmployee()
        {
            var employeeList = EmployeeList.OrderBy(x => x.Age).ToList<Employee>();
            return employeeList;
        }


    }
}
