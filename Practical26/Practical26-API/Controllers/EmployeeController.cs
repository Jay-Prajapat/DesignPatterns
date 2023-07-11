﻿using AutoMapper;
using DataAccessLibrary.Dto;
using DataAccessLibrary.Interface;
using DataAccessLibrary.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practical26_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeCommands _employeeCommands;
        private readonly IEmployeeQueries _employeeQueries;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeCommands employeeCommands,IEmployeeQueries employeeQueries,IMapper mapper)
        {
            _employeeCommands = employeeCommands;
            _employeeQueries = employeeQueries;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetStudentAsync()
        {
            var employee = await _employeeQueries.FindEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employee));  
        }

        [HttpGet("{id:int}", Name = "GetEmployeeByIdAsync")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeQueries.FindEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync(CreateEmployeeDto createEmployee)
        {
            CreateEmployeeValidator validationRules = new CreateEmployeeValidator();
            ValidationResult result = validationRules.Validate(createEmployee);
            if (!result.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToList());
                return UnprocessableEntity(ModelState);
            }
            await _employeeCommands.InsertEmployee(createEmployee);
            var createdEmployeeToReturn = _mapper.Map<EmployeeDto>(createEmployee);

            return CreatedAtRoute("GetEmployeeByIdAsync", new { id = createdEmployeeToReturn.Id }, createdEmployeeToReturn);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployee)
        {
            UpdateEmployeeValidator validationRules = new UpdateEmployeeValidator();
            ValidationResult result = validationRules.Validate(updateEmployee);

            var employeeEntity = await _employeeQueries.FindEmployeeById(id);
            if (employeeEntity is null)
            {
                return NotFound();
            }
            if (!result.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToList());
                return UnprocessableEntity(ModelState);
            }
            await _employeeCommands.UpdateEmployee(id, updateEmployee);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployeeAsync(int id)
        {
            var employeeEntity = await _employeeQueries.FindEmployeeById(id);
            if (employeeEntity is null)
            {
                return NotFound();
            }
            await _employeeCommands.DeleteEmployee(employeeEntity);
            return NoContent();
        }
    }
}
