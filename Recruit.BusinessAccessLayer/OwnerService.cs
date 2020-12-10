using System;
using Recruit.Models;
using Recruit.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class OwnerService
    {

        // public static Logger log;
        private IConfiguration _Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public OwnerService(IConfiguration _configuration)
        {
            _Configuration = _configuration;
            // log = LogManager.GetCurrentClassLogger();
        }

        public Owner Findby(int id)
        {
            OwnerEngine ownerEngine = new OwnerEngine(_Configuration);

            return ownerEngine.FindById(id);
        }
        public List<Owner> FindbyAll()
        {
            OwnerEngine ownerEngine = new OwnerEngine(_Configuration);

            return ownerEngine.FindByAll();
        }
        //public string EmployeeDetail(Employee Entities)
        //{
        //    EmployeeEngine employeeEngine = new EmployeeEngine(_Configuration);
        //    return employeeEngine.EmployeeCRU(Entities);

        //}
    }
}