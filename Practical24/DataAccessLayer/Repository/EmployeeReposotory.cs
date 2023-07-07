using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class EmployeeReposotory : IEmployeeRepository
    {
        private readonly AppplicationDBContext _dbContext = new AppplicationDBContext();
       
        public async Task AddEmployee(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _dbContext.Employees.SingleOrDefaultAsync(d => d.Id == id);
            employee.Status = false;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _dbContext.Employees.Where(e => e.Status == true).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _dbContext.Employees.SingleOrDefaultAsync(e => e.Id == id && e.Status == true);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            Employee emp = await _dbContext.Employees.SingleOrDefaultAsync(e => e.Id == employee.Id);
            if (emp != null)
            {
                _dbContext.Entry(emp).State = EntityState.Detached;
            }
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();

        }
    }
}
