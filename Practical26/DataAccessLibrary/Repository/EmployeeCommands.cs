using AutoMapper;
using DataAccessLibrary.Dto;
using DataAccessLibrary.Interface;
using DataAccessLibrary.Models;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class EmployeeCommands : IEmployeeCommands
    {
        private readonly IEmployeeCommandsRepository _employeeCommandsRepository;
        private readonly IMapper _mapper;

        public EmployeeCommands(IEmployeeCommandsRepository employeeCommandsRepository,IMapper mapper)
        {
            _employeeCommandsRepository = employeeCommandsRepository;
            _mapper = mapper;
        }
        public async Task<int> DeleteEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return await _employeeCommandsRepository.DeleteEmployeeAsync(employee);
        }

        public async Task<int> InsertEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return await _employeeCommandsRepository.CreateEmployeeAsync(employee);

        }

        public async Task<int> UpdateEmployee(int id, UpdateEmployeeDto employeeDto)
        {
            var emplpoyee = _mapper.Map<Employee>(employeeDto);
            return await _employeeCommandsRepository.UpdateEmployeeAsync(emplpoyee);
        }
    }
}
