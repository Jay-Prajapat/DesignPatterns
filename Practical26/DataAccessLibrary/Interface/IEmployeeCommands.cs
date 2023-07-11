using DataAccessLibrary.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interface
{
    public interface IEmployeeCommands
    {
        public Task<int> InsertEmployee(CreateEmployeeDto employee);
        public Task<int> DeleteEmployee(EmployeeDto employee);
        public Task<int> UpdateEmployee(int id, UpdateEmployeeDto employee);
    }
}
