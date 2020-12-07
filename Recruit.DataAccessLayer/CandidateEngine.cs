using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Recruit.Models;

namespace Recruit.DataAccessLayer
{
    public class CandidateEngine
    {
       // public static Logger log;
        private IConfiguration Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public CandidateEngine(IConfiguration _configuration)
        {
            Configuration = _configuration;
           // log = LogManager.GetCurrentClassLogger();
        }


        public List<Candidate> FindByAll()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new List<Candidate>();
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {

                    data = database.Query<Candidate>("SELECT id,first_name,last_name,email,phone,source_code,referral_id," +
                    "total_experience,relevant_experience,current_employer,current_designation,position_applied_code," +
                    "current_ctc,expected_ctc,reason_for_change,notice_period,is_serving_notice,last_working_day,current_location,process_stage_id," +
                    "process_stage_date,process_start_date,process_end_date,interview_status_id,resume_owner_id,owner_for_reminder_id," +
                    "comments,date_of_joining,notes,links_for_interview FROM tbl_Candidates").ToList();
                }

                
            }
            catch (Exception exception)
            {
               // log.Error("[DisplayCandidatesDetails]:" + exception);
            }
            return data;
        }
        public Candidate FindById(int id)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new Candidate();
            try
            {

                data = FindByAll().Where(records=>records.id==id ).FirstOrDefault();

            }
            catch (Exception exception)
            {
                // log.Error("[DisplayCandidatesDetails]:" + exception);
            }
            return data;
        }



    }
}
