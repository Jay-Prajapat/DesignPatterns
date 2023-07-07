using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practical24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _emplpoyees;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _emplpoyees = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee(int? id)
        {
            if(id != null)
            {
                var employee =await _emplpoyees.GetEmployeeById((int)id);
                return Ok(employee);
            }
            var employees =await _emplpoyees.GetAllEmployee();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            await _emplpoyees.AddEmployee(employee);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id,Employee employee)
        {
            employee.Id = id;
            await _emplpoyees.UpdateEmployee(employee);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _emplpoyees.DeleteEmployee(id);
            return Ok();
        }
    }
}
