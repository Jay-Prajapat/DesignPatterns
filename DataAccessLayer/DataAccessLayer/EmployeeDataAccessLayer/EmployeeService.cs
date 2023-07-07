using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EmployeeDataAccessLayer
{
    public class EmployeeService
    {
        private EmployeeDBContext _dbContext = EmployeeDataAccess.GetInstance();
        private Logger _logger = EmployeeDataAccess.GetLogger();

        public void AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            _logger.Log("Employee has been added successfully.");
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = _dbContext.Employees.SingleOrDefault(x => x.Id == id);
            employee.Status = false;
            _dbContext.SaveChanges();
            _logger.Log("Employee has been deleted successfully.");

        }

        public Employee GetEmployeeByID(int id)
        {
            var employee = _dbContext.Employees.Where(e => e.Status == true).SingleOrDefault(e => e.Id == id);
            if(employee == null)
            {
                _logger.Log("Employee does not exist.");
                return employee;
            }
            _logger.Log("Employee has been fetched successfully.");

            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = _dbContext.Employees.Where(e => e.Status == true).ToList();
            if (employees == null)
            {
                _logger.Log("Employees does not exist.");
                return employees;
            }
            _logger.Log("Employees has been fetched successfully.");
            return employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            Employee emp = _dbContext.Employees.SingleOrDefault(e => e.Id==employee.Id);
            if (emp != null)
            {
                _dbContext.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
            _logger.Log("Employees has been updated successfully.");

        }


    }
}
