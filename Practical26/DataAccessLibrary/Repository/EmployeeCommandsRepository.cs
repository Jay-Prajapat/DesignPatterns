using DataAccessLibrary.Database;
using DataAccessLibrary.Interface;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class EmployeeCommandsRepository : IEmployeeCommandsRepository
    {
        private readonly ApplicationDBContext _context;
        public EmployeeCommandsRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            var employeeEntity = await _context.Employees.FindAsync(employee.Id);
            if(employeeEntity != null)
            {
                employeeEntity.DeleteStatus = false;
                _context.Employees.Update(employeeEntity);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync();
        }
    }
}
