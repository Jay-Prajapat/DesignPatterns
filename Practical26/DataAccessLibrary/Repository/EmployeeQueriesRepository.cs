using DataAccessLibrary.Database;
using DataAccessLibrary.Interface;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class EmployeeQueriesRepository : IEmployeeQueriesRepository
    {
        private readonly ApplicationDBContext _context;
        public EmployeeQueriesRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id && e.DeleteStatus == true);
            if(employee != null)
            {
                _context.Entry(employee).State = EntityState.Deleted;
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.Where(e => e.DeleteStatus == true).ToListAsync();
        }
    }
}
