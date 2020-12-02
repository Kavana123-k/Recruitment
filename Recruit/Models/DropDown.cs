using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using System.Data;

namespace Recruit.Models
{
    public class DropDown
    {

        public static String connectionString = "Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True";
        /// <summary>
        /// method to get the value from tbl_owners 
        /// </summary>
        /// <returns></returns>
        public List<tbl_owners> SetOwners()
        {

            
            List<tbl_owners> items = new List<tbl_owners>();
            try
            {
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {

                        items = db.Query<tbl_owners>(" SELECT id,first_name,last_name FROM tbl_owners").ToList();
                    }
                  

            }
            catch
            {
                //writelog
            }
            return (items);
        }
        /// <summary>
        ///  method to get the value from tbl_locations
        /// </summary>
        /// <returns></returns>
        public List<tbl_locations> SetLocations()
        {
            List<tbl_locations> items = new List<tbl_locations>();
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {

                    items = db.Query<tbl_locations>(" SELECT id,city FROM tbl_locations").ToList();
                }
               
            }
            catch
            {
                //writelog
            }
            return (items);
        }
        /// <summary>
        ///  method to get the value from tbl_process_statuses
        /// </summary>
        /// <returns></returns>
        public List<tbl_process_statuses> SetProcessStatuses()
        {  
            List<tbl_process_statuses> items = new List<tbl_process_statuses>();

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {

                    items = db.Query<tbl_process_statuses>("SELECT id,code,status,colour FROM tbl_process_statuses").ToList();
                }
               
            }
            catch
            {
                //writelog
            }
            return (items);
        }
        /// <summary>
        ///  method to get the value from tbl_process_stages
        /// </summary>
        /// <returns></returns>
        public List<tbl_process_stages> SetProcessStages()
        {
            
            List<tbl_process_stages> items = new List<tbl_process_stages>();
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {

                    items = db.Query<tbl_process_stages>(" SELECT id,code,stage FROM tbl_process_stages").ToList();
                }
               
            }
            catch
            {
                //writelog
            }
            return (items);
        }
        /// <summary>
        ///  method to get the value from tbl_vacancies
        /// </summary>
        /// <returns></returns>
        public List<tbl_vacancies> SetVacancies()
        {
            List<tbl_vacancies> items = new List<tbl_vacancies>();
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {

                    items = db.Query<tbl_vacancies>(" SELECT code, name,vacancy FROM tbl_vacancies").ToList();
                }

              
            }
            catch
            {
                //writelog
            }
            return (items);
        }
        /// <summary>
        ///  method to get the value from tbl_interview_round_statuses
        /// </summary>
        /// <returns></returns>
        public List<tbl_interview_round_statuses> SetInterviewRoundStatuses()
        {
            List<tbl_interview_round_statuses> items = new List<tbl_interview_round_statuses>();
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {

                    items = db.Query<tbl_interview_round_statuses>(" SELECT id,status FROM tbl_interview_round_statuses").ToList();
                }
               
            }
            catch
            {
                //writelog
            }
            return (items);
        }
        /// <summary>
        ///  method to get the value from tbl_employees
        /// </summary>
        /// <returns></returns>
        public List<tbl_employees> SetEmployees()
        {
            List<tbl_employees> items = new List<tbl_employees>();
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {

                    items = db.Query<tbl_employees>(" SELECT id,name FROM tbl_employees").ToList();
                }


            }
            catch
            {
                //writelog
            }
            return (items);
        }
        /// <summary>
        ///  method to get the value from tbl_sources
        /// </summary>
        /// <returns></returns>
        public List<tbl_sources> SetSources()
        {
            List<tbl_sources> items = new List<tbl_sources>();
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {

                    items = db.Query<tbl_sources>("SELECT code,name FROM tbl_sources").ToList();
                }

              
            }
            catch
            {
                //writelogs
            }
            return (items);
        }
    }
}
