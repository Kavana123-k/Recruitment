//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Diagnostics;
//using System.Linq;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Recruit.Models;
//using Dapper;
//using NLog;
//using Recruit.BusinessAccessLayer;

//namespace Recruit.Controllers
//{
//    public class CandidateController : Controller
//    {
//        public static Logger log;

//        private IConfiguration Configuration;


//        ///// <summary>
//        /// constructor for configuration to use connectionstring from appsettings.json
//        /// </summary>
//        /// <param name="_configuration"></param>
//        public CandidateController(IConfiguration _configuration)
//        {
//            Configuration = _configuration;
//            log = LogManager.GetCurrentClassLogger();
//        }
//        public IActionResult Index()
//        {
//            log.Info("[Index]:Action Method returns view of the Index page");

//            return View();

//        }
//        /// <summary>
//        /// Method to display Candidate details
//        /// </summary>
//        /// <returns>Returns a list with candidates details to the view</returns>
//        public IActionResult DisplayCandidatesDetails()
//        {
//            log.Info("[DisplayCandidatesDetails]:Action Method returns view which displays the Candidates Details");
//            String connectionString = this.Configuration.GetConnectionString("MyConn");
//            var candidateBusinessAccess = new CandidateService(Configuration);
//            List<Candidate> candidate = candidateBusinessAccess.FindbyAll();
//            return View(candidate);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        [HttpGet]
//        public IActionResult InsertCandidates(int id)
//        {

//            log.Info("[InsertCandidates]:[GET]Action Method returns view which gets thepage to insert the Interview Details");
//            String connectionString = this.Configuration.GetConnectionString("MyConn");
//            var SourceBusinessAccess = new SourceService(Configuration);
//            var processStageBusinessAccess = new ProcessStageService(Configuration);
//            var ProcessStatusBusinessAccess = new ProcessStatusService(Configuration);
//            var VacancyBusinessAccess = new VacancyService(Configuration);
//            var EmployeeBusinessAccess = new EmployeeService(Configuration);
//            var OwnerBusinessAccess = new OwnerService(Configuration);
//            TempData["Sources"] = SourceBusinessAccess.FindbyAll();

//            TempData["ProcessStages"] = processStageBusinessAccess.FindbyAll();
//            TempData["ProcessStatuses"] = ProcessStatusBusinessAccess.FindbyAll();
//            TempData["Vacancies"] = VacancyBusinessAccess.FindbyAll();
//            TempData["Employees"] = EmployeeBusinessAccess.FindbyAll();
//            TempData["Owners"] = OwnerBusinessAccess.FindbyAll();


//            var candidate = new Recruit.Models.Candidate();
//            if (!string.IsNullOrWhiteSpace(id.ToString()))
//            {
//                var candidateBusinessAccess = new CandidateService(Configuration);
//                candidate = candidateBusinessAccess.Findby(id);

//            }

//            return View(candidate);
//        }


//        /// <summary>
//        /// method used to post the entries to the candidate table
//        /// </summary>
//        /// <param name="employeeEntities"></param>
//        /// <returns></returns>
//        [HttpPost]

//        public IActionResult InsertCandidates([Bind] Candidate employeeEntities)
//        {
//            String connectionString = this.Configuration.GetConnectionString("MyConn");
//            var candidateBusinessAccess = new CandidateService(Configuration);
//            log.Info("[InsertCandidates]:[Post]Action Method returns view which posts the input page to the table Candidates Details");
//            try
//            {


//                if (ModelState.IsValid)
//                {

//                    TempData["msg"] = candidateBusinessAccess.CandidateDetail(employeeEntities);
//                }
//            }
//            catch (Exception exception)
//            {
//                log.Error("[InsertCandidates]:" + exception);
//                TempData["msg"] = exception.Message;
//            }
//            finally
//            {
//                var SourceBusinessAccess = new SourceService(Configuration);
//                var processStageBusinessAccess = new ProcessStageService(Configuration);
//                var ProcessStatusBusinessAccess = new ProcessStatusService(Configuration);
//                var VacancyBusinessAccess = new VacancyService(Configuration);
//                var EmployeeBusinessAccess = new EmployeeService(Configuration);
//                var OwnerBusinessAccess = new OwnerService(Configuration);
//                TempData["Sources"] = SourceBusinessAccess.FindbyAll();

//                TempData["ProcessStages"] = processStageBusinessAccess.FindbyAll();
//                TempData["ProcessStatuses"] = ProcessStatusBusinessAccess.FindbyAll();
//                TempData["Vacancies"] = VacancyBusinessAccess.FindbyAll();
//                TempData["Employees"] = EmployeeBusinessAccess.FindbyAll();
//                TempData["Owners"] = OwnerBusinessAccess.FindbyAll();
//            }
//            return View();
//        }

//    }
//}
