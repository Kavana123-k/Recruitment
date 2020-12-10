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
    public class ProcessStatusEngine
    {

        public static Logger log;
        private IConfiguration Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public ProcessStatusEngine(IConfiguration _configuration)
        {
            Configuration = _configuration;
            log = LogManager.GetCurrentClassLogger();
        }



        /// <summary>
        ///  method to get the value from tbl_ProcessStatus
        /// </summary>
        /// <returns></returns>
        public List<ProcessStatus> FindByAll()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new List<ProcessStatus>();
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {

                    data = database.Query<ProcessStatus>("SELECT id,code,status,colour FROM tbl_process_statuses").ToList();
                }

            }
            catch (Exception exception)
            {
                log.Error("[FindByAll]: " + exception);
            }
            return (data);
        }
        /// <summary>
        /// Method is used to get the value from the db wrt to the primary key
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns></returns>
        public ProcessStatus FindById(int id)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new ProcessStatus();
            try
            {

                data = FindByAll().Where(records => records.id == id).FirstOrDefault();

            }
            catch (Exception exception)
            {
                log.Error("[FindById]:" + exception);
            }
            return data;
        }
        /// <summary>
        /// Insert or update operations on the tabl_process_statuses
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public String ProcessStatusCRU(ProcessStatus Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            try
            {
                
                if (Entities.id == 0)
                {
                     using (IDbConnection database = new SqlConnection(connectionString))
                        {
                            string insertQuery = @"INSERT INTO tbl_process_statuses([code],[status],[colour])VALUES (@code,@status,@colour)";

                            var result = database.Execute(insertQuery, new
                            {
                                Entities.code,
                                Entities.status,
                                Entities.colour

                            });
                        }
                        log.Info("[ProcessStatusCRU]:Data save Successfully");
                        return ("Data save Successfully");
                   
                }
                else
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string updateQuery = @"UPDATE tbl_process_statuses SET status=@status,colour=@colour WHERE id=@id";

                        var result = database.Execute(updateQuery, new
                        {
                            Entities.id,
                            Entities.code,
                            Entities.status,
                            Entities.colour
                        });
                    }
                    log.Info("[ProcessStatusCRU]:Data save Successfully");
                    return ("Data Updated Successfully");
                }


            }
            catch (Exception exception)
            {

                log.Error("[ProcessStatusCRU]:" + exception);
                return (exception.Message.ToString());
            }
        }
    }
}
