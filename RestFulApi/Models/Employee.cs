using System.ComponentModel.DataAnnotations;

namespace RestFulApi.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public DateTime BegınDate { get; set; }


    }
    public class EmployeeDto
    {
        public string Email { get; set; }
    }
}
