using Microsoft.AspNetCore.Mvc;
using Practice_Books.Models;
using Practice_Books.Services;

namespace Practice_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentServices _departmentService;
        public DepartmentController(DepartmentServices departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public ActionResult<List<Department>> Get() => _departmentService.GetAll();
        [HttpGet("{id}")]
        public ActionResult<Department> Get(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            return department;
        }
        [HttpPost]
        public ActionResult<Department> Post(Department department)
        {
            _departmentService.Add(department);
            return CreatedAtAction(nameof(Get), new { id = department.Id }, department);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            var existingBook = _departmentService.GetById(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            _departmentService.Update(department);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            _departmentService.Delete(id);
            return NoContent();
        }
    }
}
