using BusinessAccessLayer.Departments;
using BusinessAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.AbstractFactory
{
    public class SalesAbstractFactory : OutDoorDepartmentFactory
    {
        public IDepartment CreateDepartment()
        {
            return new Sales();
        }
    }
}
