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
    public class OwnerEngine
    {

        public static Logger log;
        private IConfiguration Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public OwnerEngine(IConfiguration _configuration)
        {
            Configuration = _configuration;
            log = LogManager.GetCurrentClassLogger();
        }



        /// <summary>
        ///  method to get the value from tbl_owners
        /// </summary>
        /// <returns></returns>
        public List<Owner> FindByAll()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var data = new List<Owner>();
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {

                    data = database.Query<Owner>(" SELECT id,first_name,last_name FROM tbl_owners").ToList();
                }


            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
            }
            return (data);
        }
        /// <summary>
        /// methods gets the contents from the db wrt to the primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Owner FindById(int id)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new Owner();
            try
            {

                data = FindByAll().Where(records => records.id == id).FirstOrDefault();

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
