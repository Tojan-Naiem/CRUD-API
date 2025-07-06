using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.DTO
{
    public class EmployeeDTO
    {
        [Required]
        [MinLength(2,ErrorMessage ="Name must be more than 2 chars")]
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }

    }
}
