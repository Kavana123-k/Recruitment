using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Recruit.Models;
using NLog;

namespace Recruit.DataAccessLayer
{
    public class EmployeeEngine
    {

        public static Logger log;
        private IConfiguration Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public EmployeeEngine(IConfiguration _configuration)
        {
            Configuration = _configuration;
            log = LogManager.GetCurrentClassLogger();
        }



        /// <summary>
        ///  method to get all the value from tbl_Employee
        /// </summary>
        /// <returns></returns>
        public List<Employee> FindByAll()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var data = new List<Employee>();
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {

                    data = database.Query<Employee>(" SELECT id,name FROM tbl_employees").ToList();
                }


            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
            }
            return (data);
        }
        /// <summary>
        /// Method gets the the values of the specified primary key
        /// </summary>
        /// <param name="code">Primary key</param>
        /// <returns></returns>
        public Employee FindByCode(string code)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new Employee();
            try
            {

                data = FindByAll().Where(records => records.id == code).FirstOrDefault();

            }
            catch (Exception exception)
            {
                log.Error("[FindByCode]:" + exception);
            }
            return data;
        }
        //public String EmployeeCRU(Employee Entities)
        //{
        //    String connectionString = this.Configuration.GetConnectionString("MyConn");

        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(Entities.code))
        //        {
        //            using (IDbConnection database = new SqlConnection(connectionString))
        //            {
        //                string insertQuery = @"INSERT INTO tbl_sources([code],[name])VALUES (@code,@name)";

        //                var result = database.Execute(insertQuery, new
        //                {
        //                    Entities.code,
        //                    Entities.name

        //                });
        //            }
        //            log.Info("[EmployeeCRU]:Data save Successfully");
        //            return ("Data save Successfully");
        //        }

        //        else
        //        {
        //            using (IDbConnection database = new SqlConnection(connectionString))
        //            {
        //                string updateQuery = @"UPDATE tbl_sources SET name=@name WHERE code=@code";

        //                var result = database.Execute(updateQuery, new
        //                {
        //                    Entities.code,
        //                    Entities.name
        //                });
        //            }
        //            log.Info("[EmployeeCRU]:Data save Successfully");
        //            return ("Data Updated Successfully");
        //        }


        //    }
        //    catch (Exception exception)
        //    {

        //        log.Error("[SourceCRU]:" + exception);
        //        return (exception.Message.ToString());
        //    }
        //}
    }
}
