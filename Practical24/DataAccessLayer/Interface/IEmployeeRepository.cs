using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeById(int id);
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task DeleteEmployee(int id);
        Task UpdateEmployee(Employee employee);
        Task AddEmployee(Employee employee);
    }
}
