using DataAccessLayer.EmployeeDataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SingletonDesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service = new EmployeeService();
        [HttpGet]
        public IActionResult GetEmployees(int? id)
        {
            if (id != null)
            {
                Employee employee = _service.GetEmployeeByID((int)id);
                return Ok(employee);
            }
            return Ok(_service.GetAllEmployees());
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _service.AddEmployee(employee);
            return Ok();
        }
        [HttpPut ]
        public IActionResult UpdateEmployee(int id,Employee employee)
        {
            employee.Id = id;
            
            _service.UpdateEmployee(employee);
            return Ok();

        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            _service.DeleteEmployee(id);
            return Ok();
        }

    }
}
