using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z ]+$", ErrorMessage = "Department Name contains only alphabets.")]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }    
    }
}
