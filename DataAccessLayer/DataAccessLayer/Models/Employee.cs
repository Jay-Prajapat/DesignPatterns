using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z ]+$", ErrorMessage = "Name contains only alphabets.")]
        public string Name { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        //[Range(typeof(DateTime), "1-1-2002", "06-07-2023", ErrorMessage = "Enter valid date.")]
        public DateTime JoiningDate { get; set; }
        public bool Status { get; set; }
        
    }
}
