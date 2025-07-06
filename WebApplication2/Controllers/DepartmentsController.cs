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
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public DepartmentsController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpPost]
        public IActionResult Create(DepartmentDTO requestDTO)
        {
            var department = requestDTO.Adapt<Department>();
            context.Department.Add(department);
            context.SaveChanges();
            return Ok();
        }        
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = context.Department.ToList();
            return Ok(departments);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var FoundedDept = context.Department.Find(Id);
            if (FoundedDept is null) return NotFound();
            context.Department.Remove(FoundedDept);
            context.SaveChanges();
            return Ok($"{FoundedDept} deleted successfully");

        }
        [HttpPut("{Id}")]
        public IActionResult Update(DepartmentDTO requestDTO,int Id)
        {
            var FoundedDept = context.Department.Find(Id);
            if (FoundedDept is null) return NotFound();
            requestDTO.Adapt(FoundedDept);
            context.SaveChanges();
            return Ok($"{FoundedDept} updated successfully");


        }


    }
}
