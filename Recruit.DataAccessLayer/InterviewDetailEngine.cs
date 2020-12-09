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
    public class InterviewDetailEngine
    {

        public static Logger log;
        private IConfiguration Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public InterviewDetailEngine(IConfiguration _configuration)
        {
            Configuration = _configuration;
            log = LogManager.GetCurrentClassLogger();
        }



        /// <summary>
        ///  method to get the value from tbl_locations
        /// </summary>
        /// <returns></returns>
        public List<InterviewDetail> FindByAll()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new List<InterviewDetail>();
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {

                    data = database.Query<InterviewDetail>("SELECT id,candidate_id,start_date_time,end_date_time,status_id,reason FROM tbl_interview_details").ToList();
                }
            }
            catch (Exception exception)
            {
                log.Error("[FindByAll]: " + exception);
            }
            return (data);
        }
        public InterviewDetail FindById(int id)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new InterviewDetail();
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
        public String InterviewDetailCRU(InterviewDetail Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            try
            {

                if (Entities.id == 0)
                {
                   
                        using (IDbConnection database = new SqlConnection(connectionString))
                        {
                            string insertQuery = @"INSERT INTO tbl_interview_details([candidate_id], [start_date_time], [end_date_time],[status_id], [reason])
                        VALUES (@candidate_id, @start_date_time, @end_date_time,@status_id, @reason)";

                            var result = database.Execute(insertQuery, new
                            {
                                Entities.candidate_id,
                                Entities.start_date_time,
                                Entities.end_date_time,
                                Entities.status_id,
                                Entities.reason
                            });
                        }
                        log.Info("[AddInterviewDetails]:Data save Successfully");
                        return ("Data save Successfully");
                    

                }
                else
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string updateQuery = @"UPDATE tbl_interview_details SET candidate_id=@candidate_id,start_date_time=@start_date_time, end_date_time=@end_date_time,status_id=@status_id,reason=@reason WHERE id=@id";

                        var result = database.Execute(updateQuery, new
                        {
                            Entities.id,
                            Entities.candidate_id,
                            Entities.start_date_time,
                            Entities.end_date_time,
                            Entities.status_id,
                            Entities.reason
                        });
                    }
                    log.Info("[InterviewDetailCRU]:Data save Successfully");
                    return ("Data Updated Successfully");
                }


            }
            catch (Exception exception)
            {

                log.Error("[InterviewDetailCRU]:" + exception);
                return (exception.Message.ToString());
            }
        }
    }
}
