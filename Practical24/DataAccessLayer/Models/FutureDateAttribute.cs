using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class FutureDateAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime date = (DateTime)value;
            return date <= DateTime.Now;
        }
    }
}
