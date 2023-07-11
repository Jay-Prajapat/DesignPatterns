using DataAccessLibrary.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interface
{
    public interface IEmployeeQueries
    {
        Task<EmployeeDto?> FindEmployeeById(int id);
        Task<IEnumerable<EmployeeDto>> FindEmployees();
    }
}
