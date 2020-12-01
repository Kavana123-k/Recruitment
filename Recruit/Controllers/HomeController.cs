using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Recruit.Models;
using Dapper;


namespace Recruit.Controllers
{
    public class HomeController : Controller
    {
      //  private readonly ILogger<HomeController> _logger;
       
        private IConfiguration Configuration;
         
        public HomeController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        DropDown dropdown = new DropDown();
        CandidatesDataAccessLayer Candidatesdb = new CandidatesDataAccessLayer();
        /// <summary>
        /// function to display the index play ie the dashboard
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Method to display interview details
        /// </summary>
        /// <returns>returns a list containing the details to the view </returns>
        public IActionResult DisplayInterviewDetails()
        {
           String connectionString = this.Configuration.GetConnectionString("MyConn");
           // String sql = "SELECT candidate_id,start_date_time,end_date_time,status_id,reason FROM tbl_interview_details";
         //   var model = new List<tbl_interview_details>();
            List<tbl_interview_details> model = new List<tbl_interview_details>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {

                model = db.Query<tbl_interview_details>("SELECT candidate_id,start_date_time,end_date_time,status_id,reason FROM tbl_interview_details").ToList();
            }
            return View(model);
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    conn.Open();
            //    using (SqlDataReader rdr = cmd.ExecuteReader())
            //    {
            //        while (rdr.Read())
            //        {
            //            var data = new tbl_interview_details
            //            {
            //                candidate_id = rdr.GetInt64(rdr.GetOrdinal("candidate_id")),
            //                start_date_time = rdr.GetDateTime(rdr.GetOrdinal("start_date_time")),
            //                end_date_time = rdr.GetDateTime(rdr.GetOrdinal("end_date_time")),
            //                status_id = rdr.GetInt64(rdr.GetOrdinal("status_id")),
            //                reason = rdr.GetString(rdr.GetOrdinal("reason")),
            //            };

            //            model.Add(data);
            //        }rdr.Close();
            //    }conn.Close();

            //}

           // return View(model);
        }
        /// <summary>
        /// Method to display Candidate details
        /// </summary>
        /// <returns>Returns a list with candidates details to the view</returns>
        public IActionResult DisplayCandidatesDetails()
        {
          String connectionString = this.Configuration.GetConnectionString("MyConn");
          //String sql = "SELECT id,first_name,last_name,email,phone,source_code,referral_id," +
          //      "total_experience,relevant_experience,current_employer,current_designation,position_applied_code," +
          //      "current_ctc,expected_ctc,reason_for_change,notice_period,is_serving_notice,last_working_day,current_location,process_stage_id," +
          //      "process_stage_date,process_start_date,process_end_date,interview_status_id,resume_owner_id,owner_for_reminder_id," +
          //      "comments,date_of_joining,notes,links_for_interview FROM tbl_Candidates";
            var model = new List<tbl_candidates>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {

                model = db.Query<tbl_candidates>("SELECT id,first_name,last_name,email,phone,source_code,referral_id," +
                "total_experience,relevant_experience,current_employer,current_designation,position_applied_code," +
                "current_ctc,expected_ctc,reason_for_change,notice_period,is_serving_notice,last_working_day,current_location,process_stage_id," +
                "process_stage_date,process_start_date,process_end_date,interview_status_id,resume_owner_id,owner_for_reminder_id," +
                "comments,date_of_joining,notes,links_for_interview FROM tbl_Candidates").ToList();
            }
            return View(model);
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    conn.Open();
            //    using (SqlDataReader rdr = cmd.ExecuteReader())
            //    {
            //        while (rdr.Read())
            //        {
            //            var data = new tbl_candidates
            //            {
            //                id = rdr.GetInt64(rdr.GetOrdinal("id")),
            //                first_name = rdr.GetString(rdr.GetOrdinal("first_name")),
            //                last_name = rdr.GetString(rdr.GetOrdinal("last_name")),
            //                email= rdr.GetString(rdr.GetOrdinal("email")),
            //                phone = rdr.GetString(rdr.GetOrdinal("phone")),
            //                source_code = rdr.GetString(rdr.GetOrdinal("source_code")),
            //                referral_id = rdr.GetString(rdr.GetOrdinal("referral_id")),
            //                total_experience = rdr.GetInt64(rdr.GetOrdinal("total_experience")),
            //                relevant_experience = rdr.GetInt64(rdr.GetOrdinal("relevant_experience")),
            //                current_employer = rdr.GetString(rdr.GetOrdinal("current_employer")),
            //                current_designation = rdr.GetString(rdr.GetOrdinal("current_designation")),
            //                position_applied_code = rdr.GetString(rdr.GetOrdinal("position_applied_code")),
            //                current_ctc = rdr.GetInt64(rdr.GetOrdinal("current_ctc")),
            //                expected_ctc = rdr.GetInt64(rdr.GetOrdinal("expected_ctc")),
            //                reason_for_change = rdr.GetString(rdr.GetOrdinal("reason_for_change")),
            //                notice_period = rdr.GetInt64(rdr.GetOrdinal("notice_period")),
            //                is_serving_notice = rdr.GetBoolean(rdr.GetOrdinal("is_serving_notice")),
            //                last_working_day = rdr.GetDateTime(rdr.GetOrdinal("last_working_day")),
            //                current_location = rdr.GetString(rdr.GetOrdinal("current_location")),
            //                process_stage_id = rdr.GetInt64(rdr.GetOrdinal("process_stage_id")),
            //                process_stage_date = rdr.GetDateTime(rdr.GetOrdinal("process_stage_date")),
            //                process_start_date = rdr.GetDateTime(rdr.GetOrdinal("process_start_date")),
            //                process_end_date = rdr.GetDateTime(rdr.GetOrdinal("process_end_date")),
            //                interview_status_id = rdr.GetInt64(rdr.GetOrdinal("interview_status_id")),
            //                resume_owner_id = rdr.GetInt64(rdr.GetOrdinal("resume_owner_id")),
            //                owner_for_reminder_id = rdr.GetInt64(rdr.GetOrdinal("owner_for_reminder_id")),
            //                comments = rdr.GetString(rdr.GetOrdinal("comments")),
            //                date_of_joining = rdr.GetDateTime(rdr.GetOrdinal("date_of_joining")),
            //                notes = rdr.GetString(rdr.GetOrdinal("notes")),
            //                links_for_interview = rdr.GetString(rdr.GetOrdinal("links_for_interview")),
            //            };
            //            model.Add(data);
            //        }rdr.Close();
            //    }conn.Close();
            //}
            //return View(model);
        }
        /// <summary>
        /// Method to display the page with forms to insert into interview details
        /// </summary>
        /// <returns>a view </returns>
        [HttpGet]
        public IActionResult InsertInterviewDetails()
        {
           
            
            TempData["Data"] = dropdown.SetInterviewRoundStatuses();
            return View();
        }
        InsertDataAccessLayer insertDB = new InsertDataAccessLayer();
        /// <summary>
        /// method used to post the inputs to the interview details table
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
         public IActionResult InsertInterviewDetails([Bind] tbl_interview_details employeeEntities)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  TempData["msg"] = insertDB.AddInterviewDetails(employeeEntities);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
        /// <summary>
        /// method is to set the page with the insertion to candidate table
        /// </summary>
        /// <returns>a view</returns>
        [HttpGet]
        public IActionResult InsertCandidates()
        {
            
           
           
            TempData["Sources"] = dropdown.SetSources();
            TempData["ProcessStages"] = dropdown.SetProcessStages();
            TempData["ProcessStatuses"] = dropdown.SetProcessStatuses();
            TempData["Vacancies"] = dropdown.SetVacancies();
            TempData["Employees"] = dropdown.SetEmployees();
            TempData["Owners"] = dropdown.SetOwners();
            // TempData.Keep();

           
            return View();
        }

        
        /// <summary>
        /// method used to post the entries to the candidate table
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult InsertCandidates([Bind] tbl_candidates employeeEntities)
        {

            try
            {
                if (ModelState.IsValid)
                {
                 
                    TempData["msg"] = Candidatesdb.AddCandidateDetails(employeeEntities);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult InsertLocations()
        {
            return View();
        }
       
        /// <summary>
        /// method used to post the inputs to the tbl_locations
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertLocations([Bind] tbl_locations cityEntities)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = insertDB.AddLocations(cityEntities);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult InsertSources()
        {
            return View();
        }
        
        /// <summary>
        /// method used to post the inputs to the tbl_sources
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertSources([Bind] tbl_sources Entities)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = insertDB.AddSources(Entities);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult InsertVacancies()
        {
            return View();
        }
        
        /// <summary>
        /// method used to post the inputs to the tbl_vacancies
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertVacancies([Bind] tbl_vacancies Entities)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = insertDB.AddVacancies(Entities);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult InsertProcessStatus()
        {
            return View();
        }
        
        /// <summary>
        /// method used to post the inputs to the tbl_process_statuses
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertProcessStatus([Bind] tbl_process_statuses Entities)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = insertDB.AddProcessStatus(Entities);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult InsertProcessStages()
        {
            return View();
        }
        
        /// <summary>
        /// method used to post the inputs to the tbl_process_stages
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertProcessStages([Bind] tbl_process_stages Entities)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = insertDB.AddProcessStages(Entities);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult InsertInterviewRoundStatuses()
        {
            return View();
        }

        /// <summary>
        /// method used to post the inputs to the tbl_interview_round_statuses
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertInterviewRoundStatuses([Bind] tbl_interview_round_statuses Entities)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = insertDB.AddRoundStatuses(Entities);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

        /// <summary>
        /// method to display the location table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayLocations()
        {
            
            List<tbl_locations> model = dropdown.SetLocations();           
            return View(model);
        }
        /// <summary>
        /// method to display the Process Statuses table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayProcessStatus()
        {
           
            List<tbl_process_statuses> model = dropdown.SetProcessStatuses();
            return View(model);
        }
        /// <summary>
        /// method to display the process stages table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayProcessStages()
        {
          
            List<tbl_process_stages> model = dropdown.SetProcessStages();
            return View(model);
        }
        /// <summary>
        /// method to display the vacancies table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayVacancies()
        {
          
            List<tbl_vacancies> model = dropdown.SetVacancies();
            return View(model);
        }
        /// <summary>
        /// method to display the employee table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayEmployees()
        {
          
            List<tbl_employees> model = dropdown.SetEmployees();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
