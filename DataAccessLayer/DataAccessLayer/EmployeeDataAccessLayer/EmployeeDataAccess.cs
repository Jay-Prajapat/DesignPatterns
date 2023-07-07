using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EmployeeDataAccessLayer
{
    public sealed class EmployeeDataAccess
    {
        public static EmployeeDBContext _dbContext;
        public static Logger _logger;
        private static readonly object _lock = new object();

        private EmployeeDataAccess() { }

        public static EmployeeDBContext GetInstance()
        {
            if (_dbContext == null)
            {
                lock (_lock)
                {
                    if (_dbContext == null)
                    {
                        _dbContext = new EmployeeDBContext();
                        return _dbContext;
                    }
                }
            }
            return _dbContext;
        }
        public static Logger GetLogger()
        {
            if (_logger == null)
            {
                lock (_lock)
                {
                    if( _logger == null)
                    {
                        _logger = new Logger();
                        return _logger;
                    }
                }
            }
            return _logger;
        }
    }
}
