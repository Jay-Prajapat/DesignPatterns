using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
   
        public string? Name { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime JoinDate { get; set; }

        [Required]
        public Department DepartmentId { get; set; }

        public bool DeleteStatus { get; set; } = true;
    }
}
