using BusinessAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Departments
{
    public class Sales : IDepartment
    {
        public decimal CalculateOverTime(int hours)
        {
            return (hours * 100);
        }
    }
}
