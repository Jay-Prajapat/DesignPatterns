using AutoMapper;
using Practical23.Dto;
using Practical23.Models;

namespace Practical23.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, CreateEmployeeDto>();

            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();

            CreateMap<Employee, EmployeeDtoHourBonus>();
        }
        
    }
}
