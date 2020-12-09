using System;
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

                    model = database.Query<tbl_interview_details>("SELECT tbl_interview_details.id,first_name," +
                        "start_date_time,end_date_time,status,reason FROM tbl_interview_details," +
                        "tbl_candidates,tbl_interview_round_statuses where" +
                        " tbl_interview_details.candidate_id = tbl_candidates.id and tbl_interview_details.status_id = tbl_interview_round_statuses.id").ToList();
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

                    //                    model = database.Query<tbl_candidates>("SELECT id, first_name, last_name," +
                    //                        "email, phone, tbl_sources.name as 'source_name' FROM tbl_Candidates, tbl_sources, tbl_employees, tbl_vacancies," +
                    //"tbl_process_stages, tbl_process_statuses, tbl_owners as t1, tbl_owners as t2" +
                    //"where tbl_candidates.source_code = tbl_sources.code and tbl_candidates.referral_id = tbl_employees.id " +
                    //"and tbl_candidates.position_applied_code = tbl_vacancies.code and tbl_candidates.process_stage_id = tbl_process_stages.id" +
                    //" and tbl_candidates.interview_status_id = tbl_process_statuses.id and tbl_candidates.resume_owner_id = t1.id " +
                    //" and tbl_candidates.owner_for_reminder_id = t2.id").ToList();
                    model = database.Query<tbl_candidates>("select  tbl_candidates.id,tbl_candidates.first_name,tbl_candidates.last_name,email,phone,tbl_sources.name as 'source_name',tbl_process_stages.stage as 'stage' from tbl_Candidates,tbl_sources where tbl_candidates.source_code=tbl_sources.code and tbl_candidates.process_stage_id=tbl_process_stages.id").ToList();
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
        public IActionResult InsertInterviewDetails(int id)
        {
            log.Info("[InsertInterviewDetails]:[Get]Action Method returns view which gets the page to insert the Interview Details");
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            TempData["Data"] = dropDown.SetInterviewRoundStatuses(connectionString);
            var interviewDetail = new Recruit.Models.InterviewDetail();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                // goto db and fetch candicate records
                //Assign to 'tblCandidate'variable
                var interviewDetailBusinessAccess = new InterviewDetailService(Configuration);
                interviewDetail = interviewDetailBusinessAccess.Findby(id);


            }

            // return model back to View
            return View(interviewDetail);
        }

        /// <summary>
        /// method used to post the inputs to the interview details table
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertInterviewDetails([Bind] InterviewDetail Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var interviewDetailBusinessAccess = new InterviewDetailService(Configuration);
            log.Info("[InsertInterviewDetails]:[Post]Action Method returns view which posts the input page to the table Interview Details");
            try
            {
                
                if (ModelState.IsValid)
                {
                    TempData["msg"] = interviewDetailBusinessAccess.InterviewDetail(Entities);
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
                   
                    TempData["msg"] = candidateBusinessAccess.CandidateDetail(employeeEntities); 
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
                    TempData["msg"] = locationBusinessAccess.LocationDetail(cityEntities);
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
                    TempData["msg"] = sourceBusinessAccess.SourceDetail(Entities);
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
                    TempData["msg"] = vacancyBusinessAccess.VacancyDetail(Entities);
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
        public IActionResult InsertProcessStatus(int id)
        {
            log.Info("[InsertProcessStatus]:[GET]Action Method returns view which gets the page to insert the Process Status Details");
            var processStatus = new Recruit.Models.ProcessStatus();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                // goto db and fetch candicate records
                //Assign to 'tblCandidate'variable
                var processStatusBusinessAccess = new ProcessStatusService(Configuration);
                processStatus = processStatusBusinessAccess.Findby(id);
            }
            return View(processStatus);
        }

        /// <summary>
        /// method used to post the inputs to the tbl_process_statuses
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertProcessStatus([Bind] ProcessStatus Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var processStatusBusinessAccess = new ProcessStatusService(Configuration);
            log.Info("[InsertProcessStatus]:[Post]Action Method returns view which posts the input page to the table Process Status Details");
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = processStatusBusinessAccess.ProcessStatusDetail(Entities);
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
        public IActionResult InsertProcessStages(int id)
        {
            log.Info("[InsertProcessStages]:[GET]Action Method returns view which gets the page to insert the Process Stages Details");
            var processStage = new Recruit.Models.ProcessStage();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                // goto db and fetch candicate records
                //Assign to 'tblCandidate'variable
                var processStageBusinessAccess = new ProcessStageService(Configuration);
                processStage = processStageBusinessAccess.Findby(id);
            }
            return View(processStage);
        }

        /// <summary>
        /// method used to post the inputs to the tbl_process_stages
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertProcessStages([Bind] ProcessStage Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var processStageBusinessAccess = new ProcessStageService(Configuration);
            log.Info("[InsertProcessStages]:[Post]Action Method returns view which posts the input page to the table Process Stages Details");
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = processStageBusinessAccess.ProcessStageDetail(Entities);
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
