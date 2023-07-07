using BusinessAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Departments
{
    internal class OnSite : IDepartment
    {
        public decimal CalculateOverTime(int hours)
        {
            return (hours * 400);
        }
    }
}
