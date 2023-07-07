using Microsoft.EntityFrameworkCore;
using Practical23.Interface;
using Practical23.Models;

namespace Practical23.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public EmployeeRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            var employeeEntity = await GetEmployeeByIdAsync(employee.Id);
            if(employeeEntity != null )
            {
                employeeEntity.Status = false;
                _dbContext.Employees.Update(employeeEntity);
            }
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id && e.Status == true);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _dbContext.Employees.Where(e => e.Status == true).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() >= 0;
        }
    }
}
