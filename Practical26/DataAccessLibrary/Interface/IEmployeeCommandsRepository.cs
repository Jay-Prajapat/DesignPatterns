using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interface
{
    public interface IEmployeeCommandsRepository
    {
        public Task<int> CreateEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(Employee employee);
    }
}
