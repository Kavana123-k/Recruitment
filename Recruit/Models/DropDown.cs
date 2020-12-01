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

            // String connectionString = this.Configuration.GetConnectionString("MyConn");
            List<tbl_owners> items = new List<tbl_owners>();
            try
            {
                //using (SqlConnection con = new SqlConnection(connectionString))
                //{
                  //  string query = " SELECT id,first_name,last_name FROM tbl_owners";
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
            // String connectionString = "Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True";
            // String connectionString = this.Configuration.GetConnectionString("MyConn");
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
        {  //  String connectionString = "Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True";
           // String connectionString = this.Configuration.GetConnectionString("MyConn");
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
            //  String connectionString = "Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True";
            // String connectionString = this.Configuration.GetConnectionString("MyConn");
            List<tbl_process_stages> items = new List<tbl_process_stages>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = " SELECT id,code,stage FROM tbl_process_stages";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    items.Add(new tbl_process_stages
                                    {
                                        id = reader.GetInt64(reader.GetOrdinal("id")),
                                        code = reader.GetString(reader.GetOrdinal("code")),
                                        stage = reader.GetString(reader.GetOrdinal("stage")),
                                    });
                                }
                                catch
                                {
                                    //writelog
                                }
                            }
                        }
                        con.Close();
                    }
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
            //   String connectionString = "Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True";
            // String connectionString = this.Configuration.GetConnectionString("MyConn");
            List<tbl_vacancies> items = new List<tbl_vacancies>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = " SELECT code, name,vacancy FROM tbl_vacancies";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    items.Add(new tbl_vacancies
                                    {
                                        code = reader.GetString(reader.GetOrdinal("code")),
                                        name = reader.GetString(reader.GetOrdinal("name")),
                                        vacancy = reader.GetInt64(reader.GetOrdinal("vacancy")),
                                    });
                                }
                                catch
                                {
                                    //writelog
                                }
                            }
                        }
                        con.Close();
                    }
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
            //  String connectionString = "Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True";
            // String connectionString = this.Configuration.GetConnectionString("MyConn");
            List<tbl_interview_round_statuses> items = new List<tbl_interview_round_statuses>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = " SELECT id,status FROM tbl_interview_round_statuses";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            try
                            {
                                while (reader.Read())
                                {
                                    items.Add(new tbl_interview_round_statuses
                                    {
                                        id = reader.GetInt64(reader.GetOrdinal("id")),
                                        status = reader.GetString(reader.GetOrdinal("status")),
                                    });
                                }
                            }
                            catch
                            {
                                //writelog
                            }
                        }
                        con.Close();
                    }
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
            //  String connectionString = "Data Source = DESKTOP-T3N0J77; Initial Catalog = RecruitMain; Integrated Security = True";
            // String connectionString = this.Configuration.GetConnectionString("MyConn");
            List<tbl_employees> items = new List<tbl_employees>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = " SELECT id,name FROM tbl_employees";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            try
                            {
                                while (reader.Read())
                                {
                                    items.Add(new tbl_employees
                                    {
                                        id = reader.GetString(reader.GetOrdinal("id")),
                                        name = reader.GetString(reader.GetOrdinal("name")),
                                    });
                                }
                            }
                            catch
                            {
                                //writelog
                            }
                        }
                        con.Close();
                    }
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


                //String connectionString = this.Configuration.GetConnectionString("MyConn");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = " SELECT code,name FROM tbl_sources";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            try
                            {
                                while (sdr.Read())
                                {
                                    items.Add(new tbl_sources
                                    {
                                        code = sdr.GetString(sdr.GetOrdinal("code")),
                                        name = sdr.GetString(sdr.GetOrdinal("name")),
                                    });
                                }
                            }
                            catch
                            {
                                //writelog
                            }
                        }
                        con.Close();
                    }
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
