using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Practical23.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practical23.Dto
{
    public class UpdateEmployeeDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name length must be between 3 and 50")]
        public string? Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary value out of range")]
        public decimal Salary { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Email length must be between 10 and 100")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        [Required]
        [EnumDataType(typeof(Department), ErrorMessage = "DepartmentId must be 0 for IT, 1 for Admin, 2 for HR, 3 for Sales, 4 for OnSite")]
        public Department DepartmentId { get; set; }

        public bool Status { get; set; } = false;
    }
}
