using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NLog;

namespace Recruit.Models
{
    public class InsertDataAccessLayer
    {
       public static SqlConnection con = new SqlConnection("Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True");
        Logger log = LogManager.GetCurrentClassLogger();
        public string AddCandidateDetails(tbl_candidates Entities)
        {

            SqlConnection con = new SqlConnection("Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True");
            Logger log = LogManager.GetCurrentClassLogger();
            try
            {

                SqlCommand cmd = new SqlCommand("sp_candidates_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //   cmd.Parameters.AddWithValue("@id", Entities.id);
                cmd.Parameters.AddWithValue("@first_name", Entities.first_name);
                cmd.Parameters.AddWithValue("@last_name", Entities.last_name);
                cmd.Parameters.AddWithValue("@email", Entities.email);
                cmd.Parameters.AddWithValue("@phone", Entities.phone);
                cmd.Parameters.AddWithValue("@source_code", Entities.source_code);
                cmd.Parameters.AddWithValue("@referral_id", Entities.referral_id);
                cmd.Parameters.AddWithValue("@total_experience", Entities.total_experience);
                cmd.Parameters.AddWithValue("@relevant_experience", Entities.relevant_experience);
                cmd.Parameters.AddWithValue("@current_employer", Entities.current_employer);
                cmd.Parameters.AddWithValue("@current_designation", Entities.current_designation);
                cmd.Parameters.AddWithValue("@position_applied_code", Entities.position_applied_code);
                cmd.Parameters.AddWithValue("@current_ctc", Entities.current_ctc);
                cmd.Parameters.AddWithValue("@expected_ctc", Entities.expected_ctc);
                cmd.Parameters.AddWithValue("@reason_for_change", Entities.reason_for_change);
                cmd.Parameters.AddWithValue("@notice_period", Entities.notice_period);
                cmd.Parameters.AddWithValue("@is_serving_notice", Entities.is_serving_notice);
                cmd.Parameters.AddWithValue("@last_working_day", Entities.last_working_day);
                cmd.Parameters.AddWithValue("@current_location", Entities.current_location);
                cmd.Parameters.AddWithValue("@process_stage_id", Entities.process_stage_id);
                cmd.Parameters.AddWithValue("@process_stage_date", Entities.process_stage_date);
                cmd.Parameters.AddWithValue("@process_start_date", Entities.process_start_date);
                cmd.Parameters.AddWithValue("@process_end_date", Entities.process_end_date);
                cmd.Parameters.AddWithValue("@interview_status_id", Entities.interview_status_id);
                cmd.Parameters.AddWithValue("@resume_owner_id", Entities.resume_owner_id);
                cmd.Parameters.AddWithValue("@owner_for_reminder_id", Entities.owner_for_reminder_id);
                cmd.Parameters.AddWithValue("@comments", Entities.comments);
                cmd.Parameters.AddWithValue("@date_of_joining", Entities.date_of_joining);
                cmd.Parameters.AddWithValue("@notes", Entities.notes);
                cmd.Parameters.AddWithValue("@links_for_interview", Entities.links_for_interview);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                log.Error(ex.Message);
                return (ex.Message.ToString());
            }
        }
        /// <summary>
        /// method to set the value for the table tbl_interview_details
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddInterviewDetails(tbl_interview_details Entities)
        {
            
            try
            {
                 SqlCommand cmd = new SqlCommand("sp_interview_details_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@candidate_id", Entities.candidate_id);
                cmd.Parameters.AddWithValue("@start_date_time",Entities.start_date_time);
                cmd.Parameters.AddWithValue("@end_date_time", Entities.end_date_time);
                cmd.Parameters.AddWithValue("@status_id", Entities.status_id );
                cmd.Parameters.AddWithValue("@reason", Entities.reason);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                log.Error(ex.Message);
                return (ex.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_locations
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddLocations(tbl_locations Entities)
        {
          //  SqlConnection con = new SqlConnection("Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True");
            try
            {

                SqlCommand cmd = new SqlCommand("sp_locations_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@city", Entities.city);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                log.Error(ex.Message);
                return (ex.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_sources
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddSources(tbl_sources Entities)
        {
          //  SqlConnection con = new SqlConnection("Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True");
            try
            {

                SqlCommand cmd = new SqlCommand("sp_sources_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", Entities.code);
                cmd.Parameters.AddWithValue("@name", Entities.name);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                log.Error(ex.Message);
                return (ex.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_vacancies
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddVacancies(tbl_vacancies Entities)
        {
          //  SqlConnection con = new SqlConnection("Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True");
            try
            {

                SqlCommand cmd = new SqlCommand("sp_vacancies_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", Entities.code);
                cmd.Parameters.AddWithValue("@name", Entities.name);
                cmd.Parameters.AddWithValue("@vacancy", Entities.vacancy);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                log.Error(ex.Message);
                return (ex.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_process_statuses
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddProcessStatus(tbl_process_statuses Entities)
        {
          //  SqlConnection con = new SqlConnection("Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True");
            try
            {

                SqlCommand cmd = new SqlCommand("sp_process_statuses_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", Entities.code);
                cmd.Parameters.AddWithValue("@status", Entities.status);
                cmd.Parameters.AddWithValue("@colour", Entities.colour);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                log.Error(ex.Message);
                return (ex.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_process_stages
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddProcessStages(tbl_process_stages Entities)
        {
           // SqlConnection con = new SqlConnection("Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True");
            try
            {

                SqlCommand cmd = new SqlCommand("sp_process_stages_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", Entities.code);
                cmd.Parameters.AddWithValue("@stage", Entities.stage);
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                log.Error(ex.Message);
                return (ex.Message.ToString());
            }
        }
        /// <summary>
        ///  method to set the value for the table tbl_interview_round_statuses
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public string AddRoundStatuses(tbl_interview_round_statuses Entities)
        {
          try
            {

                SqlCommand cmd = new SqlCommand("sp_interview_round_statuses_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
            
                cmd.Parameters.AddWithValue("@status", Entities.status);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                log.Error(ex.Message);
                return (ex.Message.ToString());
            }
        }
    }
}