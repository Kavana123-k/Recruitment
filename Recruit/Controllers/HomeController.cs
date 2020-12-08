﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Recruit.Models;
using Dapper;
using NLog;
using Recruit.BusinessAccessLayer;

namespace Recruit.Controllers
{
    public class HomeController : Controller
    {
        public static Logger log;

        private IConfiguration Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public HomeController(IConfiguration _configuration)
        {
            Configuration = _configuration;
            log = LogManager.GetCurrentClassLogger();
        }
       

        DropDown dropDown = new DropDown();
        InsertDataAccessLayer insertData = new InsertDataAccessLayer();
        
        /// <summary>
        /// function to display the index play ie the dashboard
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            log.Info("[Index]:Action Method returns view of the Index page");
          
            return View();

        }
        /// <summary>
        /// Method to display interview details
        /// </summary>
        /// <returns>returns a list containing the details to the view </returns>
        public IActionResult DisplayInterviewDetails()
        {
            log.Info("[DisplayInterviewDetails]:Action Method returns view which displays the Interview Details");
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            List<tbl_interview_details> model = new List<tbl_interview_details>();
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {

                    model = database.Query<tbl_interview_details>("SELECT candidate_id,start_date_time,end_date_time,status_id,reason FROM tbl_interview_details").ToList();
                }
            }
            catch(Exception exception)
            {
                log.Error("[DisplayInterviewDetails]:" + exception);
            }
            return View(model);

        }
        /// <summary>
        /// Method to display Candidate details
        /// </summary>
        /// <returns>Returns a list with candidates details to the view</returns>
        public IActionResult DisplayCandidatesDetails()
        {
            log.Info("[DisplayCandidatesDetails]:Action Method returns view which displays the Candidates Details");
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var model = new List<tbl_candidates>();
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {

                    model = database.Query<tbl_candidates>("SELECT id,first_name,last_name,email,phone,source_code,referral_id," +
                    "total_experience,relevant_experience,current_employer,current_designation,position_applied_code," +
                    "current_ctc,expected_ctc,reason_for_change,notice_period,is_serving_notice,last_working_day,current_location,process_stage_id," +
                    "process_stage_date,process_start_date,process_end_date,interview_status_id,resume_owner_id,owner_for_reminder_id," +
                    "comments,date_of_joining,notes,links_for_interview FROM tbl_Candidates").ToList();
                }
            }
            catch (Exception exception)
            {
                log.Error("[DisplayCandidatesDetails]:" + exception);
            }
            return View(model);
           

        }
        /// <summary>
        /// Method to display the page with forms to insert into interview details
        /// </summary>
        /// <returns>a view </returns>
        [HttpGet]
        public IActionResult InsertInterviewDetails()
        {
            log.Info("[InsertInterviewDetails]:[Get]Action Method returns view which gets the page to insert the Interview Details");
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            TempData["Data"] = dropDown.SetInterviewRoundStatuses(connectionString);
            return View();
        }

        /// <summary>
        /// method used to post the inputs to the interview details table
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertInterviewDetails([Bind] tbl_interview_details employeeEntities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            log.Info("[InsertInterviewDetails]:[Post]Action Method returns view which posts the input page to the table Interview Details");
            try
            {
                
                if (ModelState.IsValid)
                {
                    TempData["msg"] = insertData.AddInterviewDetails(employeeEntities,connectionString);
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertInterviewDetails]:" + exception);
                TempData["msg"] = exception.Message;
            }
            finally
            {
                
                TempData["Data"] = dropDown.SetInterviewRoundStatuses(connectionString);
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InsertCandidates(int id)
        {

            log.Info("[InsertCandidates]:[GET]Action Method returns view which gets thepage to insert the Interview Details");
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            TempData["Sources"] = dropDown.SetSources(connectionString);
            TempData["ProcessStages"] = dropDown.SetProcessStages(connectionString);
            TempData["ProcessStatuses"] = dropDown.SetProcessStatuses(connectionString);
            TempData["Vacancies"] = dropDown.SetVacancies(connectionString);
            TempData["Employees"] = dropDown.SetEmployees(connectionString);
            TempData["Owners"] = dropDown.SetOwners(connectionString);


            var candidate = new Recruit.Models.Candidate();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                // goto db and fetch candicate records
                //Assign to 'tblCandidate'variable
                var candidateBusinessAccess =new CandidateService(Configuration);
                candidate = candidateBusinessAccess.Findby(id);

                
            }

            // return model back to View
            return View(candidate);
        }


        /// <summary>
        /// method used to post the entries to the candidate table
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult InsertCandidates([Bind] Candidate employeeEntities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var candidateBusinessAccess = new CandidateService(Configuration);
            log.Info("[InsertCandidates]:[Post]Action Method returns view which posts the input page to the table Candidates Details");
            try
            {
              
                
                if (ModelState.IsValid)
                {
                   
                    TempData["msg"] = candidateBusinessAccess.CandidateDetails(employeeEntities); 
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertCandidates]:" + exception);
                TempData["msg"] = exception.Message;
            }
            finally
            {
                TempData["Sources"] = dropDown.SetSources(connectionString);
                TempData["ProcessStages"] = dropDown.SetProcessStages(connectionString);
                TempData["ProcessStatuses"] = dropDown.SetProcessStatuses(connectionString);
                TempData["Vacancies"] = dropDown.SetVacancies(connectionString);
                TempData["Employees"] = dropDown.SetEmployees(connectionString);
                TempData["Owners"] = dropDown.SetOwners(connectionString);
            }
            return View();
        }

        [HttpGet]
        public IActionResult InsertLocations(int id)
        {
            log.Info("[InsertLocations]:[GET]Action Method returns view which gets thepage to insert the Locations Details");
            var location = new Recruit.Models.Location();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                // goto db and fetch candicate records
                //Assign to 'tblCandidate'variable
                var locationBusinessAccess = new LocationService(Configuration);
                location = locationBusinessAccess.Findby(id);


            }

            // return model back to View
            return View(location);
           
        }

        /// <summary>
        /// method used to post the inputs to the tbl_locations
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertLocations([Bind] Location cityEntities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var locationBusinessAccess = new LocationService(Configuration);
            log.Info("[InsertLocations]:[Post]Action Method returns view which posts the input page to the table Locations Details");
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = locationBusinessAccess.LocationDetails(cityEntities);
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertLocations]:" + exception);
                TempData["msg"] = exception.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult InsertSources(string id)
        {
            log.Info("[InsertSources]:[GET]Action Method returns view which gets the page to insert the table Sources Details");
            var source= new Recruit.Models.Source();
            if (!string.IsNullOrWhiteSpace(id))
            {
                // goto db and fetch candicate records
                //Assign to 'tblCandidate'variable
                var sourceBusinessAccess = new SourceService(Configuration);
                source = sourceBusinessAccess.Findby(id);
            }
            //return model back to View
            return View(source);
      
        }

        /// <summary>
        /// method used to post the inputs to the tbl_sources
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertSources([Bind] Source Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var sourceBusinessAccess = new SourceService(Configuration);
            log.Info("[InsertSources]:[Post]Action Method returns view which posts the input page to the table Sources Details");
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = sourceBusinessAccess.SourceDetails(Entities);
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertSources]:" + exception);
                TempData["msg"] = exception.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult InsertVacancies(string id)
        {
            log.Info("[InsertVacancies]:[GET]Action Method returns view which gets the page to insert the Vacancies Details");
            var vacancy = new Recruit.Models.Vacancy();
            if (!string.IsNullOrWhiteSpace(id))
            {
                // goto db and fetch candicate records
                //Assign to 'tblCandidate'variable
                var vacancyBusinessAccess = new VacancyService(Configuration);
                vacancy = vacancyBusinessAccess.Findby(id);
            }
            //return model back to View
            return View(vacancy);
        }

        /// <summary>
        /// method used to post the inputs to the tbl_vacancies
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertVacancies([Bind] Vacancy Entities)
        {
            var vacancyBusinessAccess = new VacancyService(Configuration);
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            log.Info("[InsertVacancies]:[Post]Action Method returns view which posts the input page to the table Vacancies Details");
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = vacancyBusinessAccess.VacancyDetails(Entities);
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertVacancies]:" + exception);
                TempData["msg"] = exception.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult InsertProcessStatus()
        {
            log.Info("[InsertProcessStatus]:[GET]Action Method returns view which gets the page to insert the Process Status Details");
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
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            log.Info("[InsertProcessStatus]:[Post]Action Method returns view which posts the input page to the table Process Status Details");
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = insertData.AddProcessStatus(Entities, connectionString);
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertProcessStatus]:" + exception);
                TempData["msg"] = exception.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult InsertProcessStages()
        {
            log.Info("[InsertProcessStages]:[GET]Action Method returns view which gets the page to insert the Process Stages Details");
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
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            log.Info("[InsertProcessStages]:[Post]Action Method returns view which posts the input page to the table Process Stages Details");
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = insertData.AddProcessStages(Entities, connectionString);
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertProcessStages]:" + exception);
                TempData["msg"] = exception.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult InsertInterviewRoundStatuses()
        {
            log.Info("[InsertInterviewRoundStatuses]:[GET]Action Method returns view which gets the page to insert the table Interview Round Statuses Details");
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
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            log.Info("[InsertInterviewRoundStatuses]:[Post]Action Method returns view which posts the input page to the table Interview Round Statuses Details");
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = insertData.AddRoundStatuses(Entities, connectionString);
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertInterviewRoundStatuses]:" + exception);
                TempData["msg"] = exception.Message;
            }
            return View();
        }

        /// <summary>
        /// method to display the location table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayLocations()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            log.Info("[DisplayLocations]:Action Method returns view which displays the Locations Details");
            var model = dropDown.SetLocations(connectionString);
            return View(model);
        }
        /// <summary>
        /// method to display the Process Statuses table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayProcessStatus()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            log.Info("[DisplayProcessStatus]:Action Method returns view which displays the ProcessStatus Details");
            List<tbl_process_statuses> model = dropDown.SetProcessStatuses(connectionString);
            return View(model);
        }
        /// <summary>
        /// method to display the process stages table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayProcessStages()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            log.Info("[DisplayProcessStages]:Action Method returns view which displays the ProcessStages Details");
            List<tbl_process_stages> model = dropDown.SetProcessStages(connectionString);
            return View(model);
        }
        /// <summary>
        /// method to display the vacancies table
        /// </summary>
        /// <returns></returns>
        /// 

        public IActionResult DisplayVacancies()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            log.Info("[DisplayVacancies]:Action Method returns view which displays the Vacancies Details");
            List<tbl_vacancies> model = dropDown.SetVacancies(connectionString);
            return View(model);
        }
       
        /// <summary>
        /// method to display the employee table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayEmployees()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            log.Info("[DisplayEmployees]:Action Method returns view which displays the Employees Details");
    
            List<tbl_employees> model = dropDown.SetEmployees(connectionString);
            return View(model);
        }
        public IActionResult DisplaySources()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            log.Info("[DisplayEmployees]:Action Method returns view which displays the Employees Details");

            List<tbl_sources> model = dropDown.SetSources(connectionString);
            return View(model);
        }
        public IActionResult UpdateLocations(string id)
        {
            // Conenct to db and get the detsils for id

            // Generate a model object


            // return to view
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
