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
    public class InterviewRoundStatusEngine
    {

        public static Logger log;
        private IConfiguration Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public InterviewRoundStatusEngine(IConfiguration _configuration)
        {
            Configuration = _configuration;
            log = LogManager.GetCurrentClassLogger();
        }



        /// <summary>
        ///  Method displays all the value from InterviewRoundStatus
        /// </summary>
        /// <returns></returns>
        public List<InterviewRoundStatus> FindByAll()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var data = new List<InterviewRoundStatus>();
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {

                    data = database.Query<InterviewRoundStatus>(" SELECT id,status FROM tbl_interview_round_statuses").ToList();
                }

            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
            }
            return (data);
        }
        /// <summary>
        /// Method gets contents from the db of the specified primary key
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns></returns>
        public InterviewRoundStatus FindById(int id)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new InterviewRoundStatus();
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
        /// <summary>
        /// Create and update operation of the table InterviewRoundStatus
        /// </summary>
        /// <param name="Entities">has the content that has to be insertedd or updated</param>
        /// <returns></returns>
        public String InterviewRoundStatusEngineCRU(InterviewRoundStatus Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            try
            {
                if (Entities.id==0)
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string insertQuery = @"INSERT INTO tbl_interview_round_statuses([id],[status])VALUES (@id,@status)";

                        var result = database.Execute(insertQuery, new
                        {
                            Entities.id,
                            Entities.status

                        });
                    }
                    log.Info("[EmployeeCRU]:Data save Successfully");
                    return ("Data save Successfully");
                }

                else
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string updateQuery = @"UPDATE tbl_interview_round_statuses SET status=@status WHERE id=@id";

                        var result = database.Execute(updateQuery, new
                        {
                            Entities.id,
                            Entities.status
                        });
                    }
                    log.Info("[EmployeeCRU]:Data save Successfully");
                    return ("Data Updated Successfully");
                }


            }
            catch (Exception exception)
            {

                log.Error("[SourceCRU]:" + exception);
                return (exception.Message.ToString());
            }
        }
    }
}
