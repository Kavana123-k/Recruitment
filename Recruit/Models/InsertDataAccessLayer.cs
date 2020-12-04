using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NLog;
using Dapper;
using System.Configuration;

namespace Recruit.Models
{
    public class InsertDataAccessLayer
    {
              
        Logger log = LogManager.GetCurrentClassLogger();
        public string AddCandidateDetails(tbl_candidates Entities,String connectionString)
        {

            try
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
                                             + "@current_designation,@position_applied_code,@current_ctc,@expected_ctc,@reason_for_change,@notice_period,@is_serving_notice," +
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
            catch (Exception exception)
            {
               
                log.Error("[AddCandidateDetails]:" + exception);
                return (exception.Message.ToString());
            }
        }
        /// <summary>
        /// method to set the value for the table tbl_interview_details
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddInterviewDetails(tbl_interview_details Entities,string connectionString)
        {

            try
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
            catch (Exception exception)
            {
                
                log.Error("[AddInterviewDetails]:" + exception);
                return (exception.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_locations
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddLocations(tbl_locations Entities, string connectionString)
        {

            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {
                    string insertQuery = @"INSERT INTO tbl_locations([city])VALUES (@city)";

                    var result = database.Execute(insertQuery, new
                    {
                        Entities.city
                     
                    });
                }
                log.Info("[AddLocations]:Data save Successfully");
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
               
                log.Error("[AddLocations]:" + exception);
                return (exception.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_sources
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddSources(tbl_sources Entities, string connectionString)
        {

            try
                {

                 using (IDbConnection database = new SqlConnection(connectionString))
            {
                string insertQuery = @"INSERT INTO tbl_sources([code],[name])VALUES (@code,@name)";

                var result = database.Execute(insertQuery, new
                {
                    Entities.code,
                    Entities.name

                });
            }
                log.Info("[AddSources]:Data save Successfully");
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[AddSources]:" + exception);
                return (exception.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_vacancies
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddVacancies(tbl_vacancies Entities, string connectionString)
        {

            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {
                    string insertQuery = @"INSERT INTO tbl_vacancies([code],[name],[vacancy])VALUES (@code,@name,@vacancy)";

                    var result = database.Execute(insertQuery, new
                    {
                        Entities.code,
                        Entities.name,
                        Entities.vacancy

                    });
                }
                log.Info("[AddVacancies]:Data save Successfully");
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[AddVacancies]:" + exception);
                return (exception.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_process_statuses
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddProcessStatus(tbl_process_statuses Entities, string connectionString)
        {

            try
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
                log.Info("[AddRoundStatuses]:Data save Successfully");
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[AddProcessStatus]:" + exception);
                return (exception.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_process_stages
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddProcessStages(tbl_process_stages Entities, string connectionString)
        {
            try
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
                log.Info("[AddRoundStatuses]:Data save Successfully");
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[AddProcessStages]:" + exception);
                return (exception.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_interview_round_statuses
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddRoundStatuses(tbl_interview_round_statuses Entities, string connectionString)
        {
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {
                    string insertQuery = @"INSERT INTO tbl_interview_round_statuses([status])VALUES (@status)";

                    var result = database.Execute(insertQuery, new
                    {
                        Entities.status
                    });
                }
                log.Info("[AddRoundStatuses]:Data save Successfully");
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {

                //if (connection.State == ConnectionState.Open)
                //{
                //    connection.Close();
                //}
                log.Error("[AddRoundStatuses]:" + exception);
                return (exception.Message.ToString());
            }
        }
    }
}