﻿using BusinessAccessLayer.Departments;
using BusinessAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Factory
{
    public class AdminFactory : IDepartmentFactory
    {
        public IDepartment CreateDepartment()
        {
            return new Admin();
        }
    }
}
