using AutoMapper;
using DataAccessLibrary.Dto;
using DataAccessLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class EmployeeQueries : IEmployeeQueries
    {
        private readonly IEmployeeQueriesRepository _employeeQueriesRepository;
        private readonly IMapper _mapper;

        public EmployeeQueries(IEmployeeQueriesRepository employeeQueriesRepository,IMapper mapper)
        {
            _employeeQueriesRepository = employeeQueriesRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeDto?> FindEmployeeById(int id)
        {
            var employee = await _employeeQueriesRepository.GetEmployeeByIdAsync(id);
            return _mapper.Map<EmployeeDto?>(employee); 
        }

        public async Task<IEnumerable<EmployeeDto>> FindEmployees()
        {
            var employees = await _employeeQueriesRepository.GetEmployeesAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees); 
        }
    }
}
