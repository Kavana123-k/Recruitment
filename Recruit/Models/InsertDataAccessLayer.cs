using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Recruit.Models
{
    public class InsertDataAccessLayer
    {
       public static SqlConnection con = new SqlConnection("Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True");
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
         //   SqlConnection con = new SqlConnection("Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True");
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
                return (ex.Message.ToString());
            }
        }
    }
}