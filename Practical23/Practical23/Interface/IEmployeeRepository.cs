using Practical23.Models;

namespace Practical23.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        public Task CreateEmployeeAsync(Employee employee);
        public Task DeleteEmployeeAsync(Employee employee);
        public Task<bool> SaveChangesAsync();
    }
}
