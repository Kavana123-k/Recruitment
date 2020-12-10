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
       

       // DropDown dropDown = new DropDown();
      //  InsertDataAccessLayer insertData = new InsertDataAccessLayer();
        
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
            var interviewDetailsBusinessAccess = new InterviewDetailService(Configuration);
            List<InterviewDetail> interviewDetails = interviewDetailsBusinessAccess.FindbyAll();
            return View(interviewDetails);
          
        }
        /// <summary>
        /// Method to display Candidate details
        /// </summary>
        /// <returns>Returns a list with candidates details to the view</returns>
        public IActionResult DisplayCandidatesDetails()
        {
            log.Info("[DisplayCandidatesDetails]:Action Method returns view which displays the Candidates Details");
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var candidateBusinessAccess = new CandidateService(Configuration);
            List<Candidate> candidate = candidateBusinessAccess.FindbyAll();
             return View(candidate);
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
            var interviewRoundStatusBusinessAccess = new InterviewRoundStatusService(Configuration);
            TempData["Data"] = interviewRoundStatusBusinessAccess.FindbyAll();
            var interviewDetail = new Recruit.Models.InterviewDetail();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                var interviewDetailBusinessAccess = new InterviewDetailService(Configuration);
                interviewDetail = interviewDetailBusinessAccess.Findby(id);
            }
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
                var interviewRoundStatusBusinessAccess = new InterviewRoundStatusService(Configuration);
                TempData["Data"] = interviewRoundStatusBusinessAccess.FindbyAll();
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
            var SourceBusinessAccess = new SourceService(Configuration);
            var processStageBusinessAccess = new ProcessStageService(Configuration);
            var ProcessStatusBusinessAccess = new ProcessStatusService(Configuration);
            var VacancyBusinessAccess = new VacancyService(Configuration);
            var EmployeeBusinessAccess = new EmployeeService(Configuration);
            var OwnerBusinessAccess = new OwnerService(Configuration);
            TempData["Sources"] = SourceBusinessAccess.FindbyAll();
            
            TempData["ProcessStages"] = processStageBusinessAccess.FindbyAll();
            TempData["ProcessStatuses"] = ProcessStatusBusinessAccess.FindbyAll();
            TempData["Vacancies"] = VacancyBusinessAccess.FindbyAll();
            TempData["Employees"] = EmployeeBusinessAccess.FindbyAll();
            TempData["Owners"] = OwnerBusinessAccess.FindbyAll();


            var candidate = new Recruit.Models.Candidate();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                var candidateBusinessAccess =new CandidateService(Configuration);
                candidate = candidateBusinessAccess.Findby(id);
                               
            }

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
                var SourceBusinessAccess = new SourceService(Configuration);
                var processStageBusinessAccess = new ProcessStageService(Configuration);
                var ProcessStatusBusinessAccess = new ProcessStatusService(Configuration);
                var VacancyBusinessAccess = new VacancyService(Configuration);
                var EmployeeBusinessAccess = new EmployeeService(Configuration);
                var OwnerBusinessAccess = new OwnerService(Configuration);
                TempData["Sources"] = SourceBusinessAccess.FindbyAll();

                TempData["ProcessStages"] = processStageBusinessAccess.FindbyAll();
                TempData["ProcessStatuses"] = ProcessStatusBusinessAccess.FindbyAll();
                TempData["Vacancies"] = VacancyBusinessAccess.FindbyAll();
                TempData["Employees"] = EmployeeBusinessAccess.FindbyAll();
                TempData["Owners"] = OwnerBusinessAccess.FindbyAll();
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
                var locationBusinessAccess = new LocationService(Configuration);
                location = locationBusinessAccess.Findby(id);
            }
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
                var sourceBusinessAccess = new SourceService(Configuration);
                source = sourceBusinessAccess.Findby(id);
            }
            
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
               var vacancyBusinessAccess = new VacancyService(Configuration);
                vacancy = vacancyBusinessAccess.Findby(id);
            }
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
        public IActionResult InsertInterviewRoundStatuses([Bind] InterviewRoundStatus Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var interviewRoundStatusBusinessAccess = new InterviewRoundStatusService(Configuration);
            log.Info("[InsertInterviewRoundStatuses]:[Post]Action Method returns view which posts the input page to the table Interview Round Statuses Details");
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = interviewRoundStatusBusinessAccess.InterviewRoundStatusDetail(Entities);
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
            
            log.Info("[DisplayLocations]:Action Method returns view which displays the Locations Details");
            var locationBusinessAccess = new LocationService(Configuration);
            List<Location> location = locationBusinessAccess.FindbyAll();
            return View(location);
        }
        /// <summary>
        /// method to display the Process Statuses table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayProcessStatus()
        {
            log.Info("[DisplayProcessStatus]:Action Method returns view which displays the Locations Details");
            var processStatusBusinessAccess = new ProcessStatusService(Configuration);
            List<ProcessStatus> processStatus = processStatusBusinessAccess.FindbyAll();
            return View(processStatus);
        }
        /// <summary>
        /// method to display the process stages table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayProcessStages()
        {
            log.Info("[DisplayProcessStages]:Action Method returns view which displays the Locations Details");
            var processStageBusinessAccess = new ProcessStageService(Configuration);
            List<ProcessStage> processStage = processStageBusinessAccess.FindbyAll();
            return View(processStage);
        }
        /// <summary>
        /// method to display the vacancies table
        /// </summary>
        /// <returns></returns>
        /// 

        public IActionResult DisplayVacancies()
        {
            log.Info("[DisplayVacancies]:Action Method returns view which displays the Locations Details");
            var vacanciesBusinessAccess = new VacancyService(Configuration);
            List<Vacancy> vacancy = vacanciesBusinessAccess.FindbyAll();
            return View(vacancy);
        }
       
        /// <summary>
        /// method to display the employee table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayEmployees()
        {
            log.Info("[DisplayEmployees]:Action Method returns view which displays the Locations Details");
            var EmployeeBusinessAccess = new EmployeeService(Configuration);
            List<Employee> employee = EmployeeBusinessAccess.FindbyAll();
            return View(employee);
        }
        public IActionResult DisplaySources()
        {
            log.Info("[DisplaySource]:Action Method returns view which displays the Locations Details");
            var sourceBusinessAccess = new SourceService(Configuration);
            List<Source> source = sourceBusinessAccess.FindbyAll();
            return View(source);
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
