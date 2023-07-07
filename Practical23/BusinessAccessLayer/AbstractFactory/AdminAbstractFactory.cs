using BusinessAccessLayer.Departments;
using BusinessAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.AbstractFactory
{
    public class AdminAbstractFactory : IndoorDepartmentFactory
    {
        public IDepartment CreateDepartment()
        {
            return new Admin();
        }
    }
}
