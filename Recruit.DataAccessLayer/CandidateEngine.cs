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
    public class CandidateEngine
    {
        public static Logger log;
        private IConfiguration Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public CandidateEngine(IConfiguration _configuration)
        {
            Configuration = _configuration;
           log = LogManager.GetCurrentClassLogger();
        }


        public List<Candidate> FindByAll()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new List<Candidate>();
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {

                    data = database.Query<Candidate>("SELECT tbl_candidates.id, tbl_candidates.first_name, tbl_candidates.last_name,"+
                        "email, phone, tbl_sources.name as 'source_name', tbl_employees.name as 'emp_ref',"+
"total_experience, relevant_experience, current_employer, current_designation,"+
"tbl_vacancies.name as 'position',current_ctc, expected_ctc, reason_for_change, notice_period, is_serving_notice,"+
"last_working_day, current_location, tbl_process_stages.stage as 'stage',process_stage_date, process_start_date,"+
"process_end_date, tbl_process_statuses.status as 'status',t1.first_name as 'owner', t2.first_name as 'remind',"+
"comments, date_of_joining, notes, links_for_interview FROM tbl_Candidates, tbl_sources, tbl_employees, tbl_vacancies,"+
"tbl_process_stages, tbl_process_statuses, tbl_owners as t1, tbl_owners as t2"+
"where tbl_candidates.source_code = tbl_sources.code and tbl_candidates.referral_id = tbl_employees.id " +
"and tbl_candidates.position_applied_code = tbl_vacancies.code and tbl_candidates.process_stage_id = tbl_process_stages.id" +
" and tbl_candidates.interview_status_id = tbl_process_statuses.id and tbl_candidates.resume_owner_id = t1.id " +
" and tbl_candidates.owner_for_reminder_id = t2.id").ToList();
                }

                
            }
            catch (Exception exception)
            {
               log.Error("[DisplayCandidatesDetails]:" + exception);
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
                 log.Error("[DisplayCandidatesDetails]:" + exception);
            }
            return data;
        }
        public String CandidateCRU(Candidate Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            try
            {
                if (Entities.id == 0)
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string insertQuery = @"INSERT INTO tbl_candidates([first_name],[last_name],[email],[phone],[source_code],[referral_id],
                                          [total_experience],[relevant_experience],[current_employer],[current_designation],[position_applied_code],
                                          [current_ctc],[expected_ctc],[reason_for_change],[notice_period],[is_serving_notice],[last_working_day],
                                          [current_location],[process_stage_id],[process_stage_date],[process_start_date],[process_end_date],[interview_status_id],
                                          [resume_owner_id],[owner_for_reminder_id],[comments],[date_of_joining],[notes],[links_for_interview])
                                           VALUES 
                                            (@first_name,@last_name,@email,@phone,@source_code,@referral_id,@total_experience,@relevant_experience,@current_employer,"
                                                 + "@current_designation,@position_applied_code,@current_ctc,@expected_ctc,@reason_for_change,@notice_period," +
                                                 "@is_serving_notice," +
                                                 "@last_working_day,@current_location,@process_stage_id,@process_stage_date,@process_start_date,@process_end_date," +
                                                 "@interview_status_id,@resume_owner_id,@owner_for_reminder_id,@comments,@date_of_joining,@notes,@links_for_interview )";

                        var result = database.Execute(insertQuery, new
                        {
                            Entities.first_name,
                            Entities.last_name,
                            Entities.email,
                            Entities.phone,
                            Entities.source_code,
                            Entities.referral_id,
                            Entities.total_experience,
                            Entities.relevant_experience,
                            Entities.current_employer,
                            Entities.current_designation,
                            Entities.position_applied_code,
                            Entities.current_ctc,
                            Entities.expected_ctc,
                            Entities.reason_for_change,
                            Entities.notice_period,
                            Entities.is_serving_notice,
                            Entities.last_working_day,
                            Entities.current_location,
                            Entities.process_stage_id,
                            Entities.process_stage_date,
                            Entities.process_start_date,
                            Entities.process_end_date,
                            Entities.interview_status_id,
                            Entities.resume_owner_id,
                            Entities.owner_for_reminder_id,
                            Entities.comments,
                            Entities.date_of_joining,
                            Entities.notes,
                            Entities.links_for_interview

                        });
                    }
                    log.Info("[AddCandidateDetails]:Data save Successfully");
                    return ("Data save Successfully");
                }
                else
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string updateQuery = @"UPDATE tbl_candidates SET first_name=@first_name,last_name=@last_name,email=@email,phone=@phone,
                                            source_code=@source_code,referral_id=@referral_id,total_experience=@total_experience,relevant_experience=@relevant_experience,
                                            current_employer=@current_employer,current_designation=@current_designation,position_applied_code=@position_applied_code,
                                            current_ctc=@current_ctc,expected_ctc=@expected_ctc,reason_for_change=@reason_for_change,notice_period=@notice_period,
                                            is_serving_notice=@is_serving_notice,last_working_day=@last_working_day,current_location=@current_location,
                                            process_stage_id=@process_stage_id,process_stage_date=@process_stage_date,process_start_date=@process_start_date,
                                            process_end_date=@process_end_date,interview_status_id=@interview_status_id,resume_owner_id=@resume_owner_id,
                                             owner_for_reminder_id=@owner_for_reminder_id,comments=@comments,date_of_joining=@date_of_joining,notes=@notes,
                                            links_for_interview=@links_for_interview  WHERE id=@id";

                        var result = database.Execute(updateQuery, new
                        {
                            Entities.id,
                            Entities.first_name,
                            Entities.last_name,
                            Entities.email,
                            Entities.phone,
                            Entities.source_code,
                            Entities.referral_id,
                            Entities.total_experience,
                            Entities.relevant_experience,
                            Entities.current_employer,
                            Entities.current_designation,
                            Entities.position_applied_code,
                            Entities.current_ctc,
                            Entities.expected_ctc,
                            Entities.reason_for_change,
                            Entities.notice_period,
                            Entities.is_serving_notice,
                            Entities.last_working_day,
                            Entities.current_location,
                            Entities.process_stage_id,
                            Entities.process_stage_date,
                            Entities.process_start_date,
                            Entities.process_end_date,
                            Entities.interview_status_id,
                            Entities.resume_owner_id,
                            Entities.owner_for_reminder_id,
                            Entities.comments,
                            Entities.date_of_joining,
                            Entities.notes,
                            Entities.links_for_interview
                        });
                    }
                    log.Info("[AddCandidateDetails]:Data save Successfully");
                    return ("Data Updated Successfully");
                }
                

            }
            catch (Exception exception)
            {

               log.Error("[AddCandidateDetails]:" + exception);
                return (exception.Message.ToString());
            }
        }


    }
}
