using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public EmployeesController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpPost]
        public IActionResult Create(EmployeeDTO requestDTO)
        {

            var employee = requestDTO.Adapt<Employee>();
            context.Employees.Add(employee);
            context.SaveChanges();
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult Update(EmployeeDTO requestDTO, int Id)
        {
            var FoundedEmployee = context.Employees.Find(Id);
            if (FoundedEmployee is null) return NotFound();
            requestDTO.Adapt(FoundedEmployee);
            context.SaveChanges();
            return Ok($"{FoundedEmployee} updated successfully");
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var FoundedEmployee = context.Employees.Find(Id);
            if (FoundedEmployee is null) return NotFound();
            context.Employees.Remove(FoundedEmployee);
            context.SaveChanges();
            return Ok($"{FoundedEmployee} deleted successfully");
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var EmployeeDTOs = context.Employees.ToList().Adapt<List<EmployeeDTO>>();
            return Ok(EmployeeDTOs);
        }
    }
}
