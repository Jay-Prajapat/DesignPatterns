using AutoMapper;
using DataAccessLibrary.Dto;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, CreateEmployeeDto>();
            CreateMap<CreateEmployeeDto, EmployeeDto>();

            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();
            CreateMap<UpdateEmployeeDto, EmployeeDto>();
        }
    }
}
