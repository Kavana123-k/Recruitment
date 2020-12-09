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
    public class ProcessStageEngine
    {

        public static Logger log;
        private IConfiguration Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public ProcessStageEngine(IConfiguration _configuration)
        {
            Configuration = _configuration;
            log = LogManager.GetCurrentClassLogger();
        }



        /// <summary>
        ///  method to get the value from tbl_locations
        /// </summary>
        /// <returns></returns>
        public List<ProcessStage> FindByAll()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new List<ProcessStage>();
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {

                    data = database.Query<ProcessStage>(" SELECT id,code,stage FROM tbl_process_stages").ToList();
                }

            }
            catch (Exception exception)
            {
                log.Error("[FindByAll]: " + exception);
            }
            return (data);
        }
        public ProcessStage FindById(int id)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new ProcessStage();
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
        public String ProcessStageCRU(ProcessStage Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            try
            {

                if (Entities.id == 0)
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string insertQuery = @"INSERT INTO tbl_process_stages([code],[stage])VALUES (@code,@stage)";

                        var result = database.Execute(insertQuery, new
                        {
                            Entities.code,
                            Entities.stage
                        });
                    }
                    log.Info("[ProcessStageCRU]:Data save Successfully");
                    return ("Data save Successfully");

                }
                else
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string updateQuery = @"UPDATE tbl_process_stages SET code=@code,stage=@stage WHERE id=@id";

                        var result = database.Execute(updateQuery, new
                        {
                            Entities.id,
                            Entities.code,
                            Entities.stage,
                            
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
