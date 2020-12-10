using System;
using Recruit.Models;
using Recruit.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class EmployeeService
    {

        // public static Logger log;
        private IConfiguration _Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public EmployeeService(IConfiguration _configuration)
        {
            _Configuration = _configuration;
            // log = LogManager.GetCurrentClassLogger();
        }

        public Employee Findby(String code)
        {
            EmployeeEngine employeeEngine = new EmployeeEngine(_Configuration);

            return employeeEngine.FindByCode(code);
        }
        public List<Employee> FindbyAll()
        {
            EmployeeEngine employeeEngine = new EmployeeEngine(_Configuration);

            return employeeEngine.FindByAll();
        }
        //public string EmployeeDetail(Employee Entities)
        //{
        //    EmployeeEngine employeeEngine = new EmployeeEngine(_Configuration);
        //    return employeeEngine.EmployeeCRU(Entities);

        //}
    }
}