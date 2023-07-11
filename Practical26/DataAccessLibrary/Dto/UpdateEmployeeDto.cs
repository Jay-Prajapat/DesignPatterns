using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Dto
{
    public class UpdateEmployeeDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name length must be between 3 and 50")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Email length must be between 10 and 100")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "DepartmentId is required")]
        [EnumDataType(typeof(Department), ErrorMessage = "DepartmentId must be 0 for IT, 1 for Admin, 2 for HR, 3 for Sales, 4 for OnSite")]
        public Department DepartmentId { get; set; }

        public bool DeleteStatus { get; set; } = true;
    }
}
