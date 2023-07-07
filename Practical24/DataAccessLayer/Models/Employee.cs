using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"[a-zA-Z ]+$",ErrorMessage ="Name contains characters only.")]
        public string? Name { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [FutureDate(ErrorMessage = "Please select a date in the past or today.")]
        public DateTime JoinDate { get; set; }

        [Required]
        public Department DepartmentId { get; set; }

        public bool Status { get; set; } = true;
    }
}
