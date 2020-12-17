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
//using NLog;
using Recruit.BusinessAccessLayer;
using Recruit.DataAccessLayer.Interface;
using Recruit.DataAccessLayer;
using log4net.Repository.Hierarchy;
using log4net;
using Microsoft.Extensions.Logging;

namespace Recruit.Controllers
{
    public class HomeController : Controller
    {
      //  public static Logger log;
        private readonly ILogger _logger;


        //private IConfiguration Configuration;

        //IUnitOfWork unitOfWork;

        /// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        //public HomeController(IConfiguration _configuration)
        //{
        //    Configuration = _configuration;
        //    log = LogManager.GetCurrentClassLogger();
        //}
        //  private IUnitOfWork unitOfWork;

        static Recruit.BusinessAccessLayer.Interface.IService<Candidate> _serviceCandidate;
        static Recruit.BusinessAccessLayer.Interface.IService<Location> _serviceLocation;
        static Recruit.BusinessAccessLayer.Interface.IService<Employee> _serviceEmployee;
        static Recruit.BusinessAccessLayer.Interface.IService<InterviewDetail> _serviceInterviewDetail;
        static Recruit.BusinessAccessLayer.Interface.IService<InterviewRoundStatus> _serviceInterviewRoundStatus;
        static Recruit.BusinessAccessLayer.Interface.IService<Owner> _serviceOwner;
        static Recruit.BusinessAccessLayer.Interface.IService<ProcessStatus> _serviceProcessStatus;
        static Recruit.BusinessAccessLayer.Interface.IService<ProcessStage> _serviceProcessStage;
        static Recruit.BusinessAccessLayer.Interface.IService<Vacancy> _serviceVacancy;
        static Recruit.BusinessAccessLayer.Interface.IService<Source> _serviceSource;
        public HomeController(Recruit.BusinessAccessLayer.Interface.IService<Candidate> serviceCanidate,
                                Recruit.BusinessAccessLayer.Interface.IService<Location> serviceLocation,
                                Recruit.BusinessAccessLayer.Interface.IService<Employee> serviceEmployee,
                                Recruit.BusinessAccessLayer.Interface.IService<InterviewDetail> serviceInterviewDetail,
            Recruit.BusinessAccessLayer.Interface.IService<InterviewRoundStatus> serviceInterviewRoundStatus,
            Recruit.BusinessAccessLayer.Interface.IService<Owner> serviceOwner,
            Recruit.BusinessAccessLayer.Interface.IService<ProcessStatus> serviceProcessStatus,
            Recruit.BusinessAccessLayer.Interface.IService<ProcessStage> serviceProcessStage,
            Recruit.BusinessAccessLayer.Interface.IService<Vacancy> serviceVacancy,
            Recruit.BusinessAccessLayer.Interface.IService<Source> serviceSource)
        {
            _serviceCandidate = serviceCanidate;
            _serviceLocation = serviceLocation;
            _serviceEmployee = serviceEmployee;
            _serviceInterviewDetail = serviceInterviewDetail;
            _serviceInterviewRoundStatus = serviceInterviewRoundStatus;
            _serviceOwner = serviceOwner;
            _serviceProcessStatus = serviceProcessStatus;
            _serviceProcessStage = serviceProcessStage;
            _serviceVacancy = serviceVacancy;
            _serviceSource = serviceSource;


            //log = LogManager.GetCurrentClassLogger();
            //_logger = logger;
        }


        /// <summary>
        /// function to display the index play ie the dashboard
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //     _logger.LogInformation("[Index]:Action Method returns view of the Index page###########################");
         
           return View();
        }
        public IActionResult DisplayCandidatesDetails()
        {
            //log.Info("[DisplayCandidatesDetails]:Action Method returns view which displays the Candidates Details");
            var data = _serviceCandidate.FindbyAll();
            return View(data);
        }

        /// <summary>
        /// Method to display the page with forms to insert into interview details
        /// </summary>
        /// <returns>a view </returns>
        [HttpGet]
        public IActionResult InsertInterviewDetails(int id)
        {
           // log.Info("[InsertInterviewDetails]:[Get]Action Method returns view which gets the page to insert the Interview Details");
          
            TempData["Data"] = _serviceInterviewRoundStatus.FindbyAll();
            var interviewDetail = new InterviewDetail();
            var interviewDetailAll = new List<InterviewDetail>();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                interviewDetail = _serviceInterviewDetail.FindBy(id);
                return View(interviewDetail);
                
            }
            else
            {
                interviewDetailAll = _serviceInterviewDetail.FindbyAll();
                return View(interviewDetailAll);
            }
          
        }

        /// <summary>
        /// method used to post the inputs to the interview details table
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertInterviewDetails([Bind] InterviewDetail entity)
        {
            TempData["Data"] = _serviceInterviewRoundStatus.FindbyAll();
            // log.Info("[InsertInterviewDetails]:[Post]Action Method returns view which posts the input page to the table Interview Details");
            if (entity.id == 0)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceInterviewDetail.Insert(entity);
                    }
                }
                catch (Exception exception)
                {
                  //  log.Error("[InsertInterviewDetails]:" + exception);
                    TempData["msg"] = exception.Message;
                }
               
            }
            else
            {
                try
                { 
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceInterviewDetail.Update(entity);
                    }
                }
                catch (Exception exception)
                {
                   // log.Error("[InsertInterviewDetails]:" + exception);
                    TempData["msg"] = exception.Message;
                }
               
            }
            return View();
        }

        /// <summary>
        /// Method to Display a page for insert
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InsertCandidates(int id)
        {

           // log.Info("[InsertCandidates]:[GET]Action Method returns view which gets thepage to insert the Interview Details");

                TempData["Sources"] = _serviceSource.FindbyAll();
                TempData["ProcessStages"] = _serviceProcessStage.FindbyAll();
                TempData["ProcessStatuses"] = _serviceProcessStatus.FindbyAll();
                TempData["Vacancies"] = _serviceVacancy.FindbyAll();
                TempData["Employees"] = _serviceEmployee.FindbyAll();
                TempData["Owners"] = _serviceOwner.FindbyAll();

            var candidate = new Candidate();
            var candidateAll = new List<Candidate>();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                candidate = _serviceCandidate.FindBy(id);
                return View(candidate);

            }
            else
            {
                candidateAll = _serviceCandidate.FindbyAll();
                return View(candidateAll);
            }
        }


        /// <summary>
        /// method used to post the entries to the candidate table
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult InsertCandidates([Bind] Candidate entity)
        {
            //  log.Info("[InsertCandidates]:[Post]Action Method returns view which posts the input page to the table Candidates Details");
            TempData["Sources"] = _serviceSource.FindbyAll();
            TempData["ProcessStages"] = _serviceProcessStage.FindbyAll();
            TempData["ProcessStatuses"] = _serviceProcessStatus.FindbyAll();
            TempData["Vacancies"] = _serviceVacancy.FindbyAll();
            TempData["Employees"] = _serviceEmployee.FindbyAll();
            TempData["Owners"] = _serviceOwner.FindbyAll();
            if (entity.id == 0)
            {
                try
                {


                    if (ModelState.IsValid)
                    {

                        TempData["msg"] = _serviceCandidate.Insert(entity);
                    }
                }
                catch (Exception exception)
                {
                   // log.Error("[InsertCandidates]:" + exception);
                    TempData["msg"] = exception.Message;
                }
               
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        TempData["msg"] = _serviceCandidate.Update(entity);
                    }
                }
                catch (Exception exception)
                {
                    // log.Error("[InsertCandidates]:" + exception);
                    TempData["msg"] = exception.Message;
                }
                finally
                {

                    TempData["Sources"] = _serviceSource.FindbyAll();

                    TempData["ProcessStages"] = _serviceProcessStage.FindbyAll();
                    TempData["ProcessStatuses"] = _serviceProcessStatus.FindbyAll();
                    TempData["Vacancies"] = _serviceVacancy.FindbyAll();
                    TempData["Employees"] = _serviceEmployee.FindbyAll();
                    TempData["Owners"] = _serviceOwner.FindbyAll();
                }
            }
           
            return View();
        }

        [HttpGet]
        public IActionResult InsertLocations(int id)
        {
            // log.Info("[InsertLocations]:[GET]Action Method returns view which gets thepage to insert the Locations Details");
            
            var location = new Location();
            var locationAll = new List<Location>();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                location = _serviceLocation.FindBy(id);
                return View(location);
                
            }
            else
            {
                locationAll = _serviceLocation.FindbyAll();
                return View(locationAll);
            }
           

        }

        /// <summary>
        /// method used to post the inputs to the tbl_locations
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertLocations([Bind] Location entity)
        {
           
            //  log.Info("[InsertLocations]:[Post]Action Method returns view which posts the input page to the table Locations Details");
            if (entity.id == 0)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceLocation.Insert(entity);
                    }
                }
                catch (Exception exception)
                {
                    //   log.Error("[InsertLocations]:" + exception);
                    TempData["msg"] = exception.Message;
                }
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceLocation.Update(entity);
                    }
                }
                catch (Exception exception)
                {
                    //   log.Error("[InsertLocations]:" + exception);
                    TempData["msg"] = exception.Message;
                }

            }
            return View();
        }
        /// <summary>
        /// Method to display the page for insertion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InsertSources(int id)
        {
           // log.Info("[InsertSources]:[GET]Action Method returns view which gets the page to insert the table Sources Details");
            var source = new Source();
            var soucrceAll = new List<Source>();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                source = _serviceSource.FindBy(id);
                return View(source);
                
            }
            else
            {
                soucrceAll = _serviceSource.FindbyAll();
                return View(soucrceAll);
            }
        }

        /// <summary>
        /// method used to post the inputs to the tbl_sources
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertSources([Bind] Source entity)
        {

            //  log.Info("[InsertSources]:[Post]Action Method returns view which posts the input page to the table Sources Details");
            if (entity.id == 0)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceSource.Insert(entity);
                    }
                }
                catch (Exception exception)
                {
                    //  log.Error("[InsertSources]:" + exception);
                    TempData["msg"] = exception.Message;
                }
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceSource.Update(entity);
                    }
                }
                catch (Exception exception)
                {
                    // log.Error("[InsertSources]:" + exception);
                    TempData["msg"] = exception.Message;
                }

            }
            return View();
        }
        /// <summary>
        /// Method to display the page to insert
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InsertVacancies(int id)
        {
            //log.Info("[InsertVacancies]:[GET]Action Method returns view which gets the page to insert the Vacancies Details");
            var vacancy = new Vacancy();
            var vacancyAll = new List<Vacancy>();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                vacancy = _serviceVacancy.FindBy(id);
                return View(vacancy);

            }
            else
            {
                vacancyAll = _serviceVacancy.FindbyAll();
                return View(vacancyAll);
            }
        }

        /// <summary>
        /// method used to post the inputs to the tbl_vacancies
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertVacancies([Bind] Vacancy entity)
        {

            //  log.Info("[InsertVacancies]:[Post]Action Method returns view which posts the input page to the table Vacancies Details");
            if (entity.id == 0)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceVacancy.Insert(entity);
                    }
                }
                catch (Exception exception)
                {
                   // log.Error("[InsertVacancies]:" + exception);
                    TempData["msg"] = exception.Message;
                }
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceVacancy.Update(entity);
                    }
                }
                catch (Exception exception)
                {
                   // log.Error("[InsertVacancies]:" + exception);
                    TempData["msg"] = exception.Message;
                }

            }
            return View();
        }
        /// <summary>
        /// Method to display a page for insert
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InsertProcessStatus(int id)
        {
           // log.Info("[InsertProcessStatus]:[GET]Action Method returns view which gets the page to insert the Process Status Details");
            var processStatus = new ProcessStatus();
            var processStatusAll = new List<ProcessStatus>();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                processStatus = _serviceProcessStatus.FindBy(id);
                return View(processStatus);

            }
            else
            {
                processStatusAll = _serviceProcessStatus.FindbyAll();
                return View(processStatusAll);
            }
        }

        /// <summary>
        /// method used to post the inputs to the tbl_process_statuses
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertProcessStatus([Bind] ProcessStatus entity)
        {

            // log.Info("[InsertProcessStatus]:[Post]Action Method returns view which posts the input page to the table Process Status Details");
            if (entity.id == 0)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceProcessStatus.Insert(entity);
                    }
                }
                catch (Exception exception)
                {
                  //  log.Error("[InsertProcessStatus]:" + exception);
                    TempData["msg"] = exception.Message;
                }
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceProcessStatus.Update(entity);
                    }
                }
                catch (Exception exception)
                {
                  //  log.Error("[InsertProcessStatus]:" + exception);
                    TempData["msg"] = exception.Message;
                }

            }
            return View();
        }
        /// <summary>
        /// Method to display the page to insert
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InsertProcessStages(int id)
        {
           // log.Info("[InsertProcessStages]:[GET]Action Method returns view which gets the page to insert the Process Stages Details");
            var processStage = new ProcessStage();
            var processStageAll = new List<ProcessStage>();
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                processStage = _serviceProcessStage.FindBy(id);
                return View(processStage);

            }
            else
            {
                processStageAll = _serviceProcessStage.FindbyAll();
                return View(processStageAll);
            }
        }

        /// <summary>
        /// method used to post the inputs to the tbl_process_stages
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertProcessStages([Bind] ProcessStage entity)
        {
            if (entity.id == 0)
            {

                // log.Info("[InsertProcessStages]:[Post]Action Method returns view which posts the input page to the table Process Stages Details");
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceProcessStage.Insert(entity);
                    }
                }
                catch (Exception exception)
                {
                    //log.Error("[InsertProcessStages]:" + exception);
                    TempData["msg"] = exception.Message;
                }
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceProcessStage.Update(entity);
                    }
                }
                catch (Exception exception)
                {
                    //log.Error("[InsertProcessStages]:" + exception);
                    TempData["msg"] = exception.Message;
                }
            }
            return View();
        }
        /// <summary>
        /// Method used to display the page for insert
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InsertInterviewRoundStatuses()
        {
           // log.Info("[InsertInterviewRoundStatuses]:[GET]Action Method returns view which gets the page to insert the table Interview Round Statuses Details");
            return View();
        }

        /// <summary>
        /// method used to post the inputs to the tbl_interview_round_statuses
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertInterviewRoundStatuses([Bind] InterviewRoundStatus entity)
        {

            if (entity.id == 0)
            {

                // log.Info("[InsertInterviewRoundStatuses]:[Post]Action Method returns view which posts the input page to the table Interview Round Statuses Details");
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceInterviewRoundStatus.Insert(entity);
                    }
                }
                catch (Exception exception)
                {
                    //  log.Error("[InsertInterviewRoundStatuses]:" + exception);
                    TempData["msg"] = exception.Message;
                }
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        TempData["msg"] = _serviceInterviewRoundStatus.Update(entity);
                    }
                }
                catch (Exception exception)
                {
                    //  log.Error("[InsertInterviewRoundStatuses]:" + exception);
                    TempData["msg"] = exception.Message;
                }

            }
            return View();
        }
        /// <summary>
        /// Method to display interview details
        /// </summary>
        /// <returns>returns a list containing the details to the view </returns>
        public IActionResult DisplayInterviewDetails()
        {
           
            List<InterviewDetail> interviewDetails = _serviceInterviewDetail.FindbyAll();
            return View(interviewDetails);

        }

        /// <summary>
        /// method to display the location table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayLocations()
        {

           // log.Info("[DisplayLocations]:Action Method returns view which displays the Locations Details");
          List<Location> location = _serviceLocation.FindbyAll();
            return View(location);
        }
        /// <summary>
        /// method to display the Process Statuses table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayProcessStatus()
        {
           // log.Info("[DisplayProcessStatus]:Action Method returns view which displays the Locations Details");
           
            List<ProcessStatus> processStatus = _serviceProcessStatus.FindbyAll();
            return View(processStatus);
        }
        /// <summary>
        /// method to display the process stages table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayProcessStages()
        {
           // log.Info("[DisplayProcessStages]:Action Method returns view which displays the Locations Details");
           
            List<ProcessStage> processStage = _serviceProcessStage.FindbyAll();
            return View(processStage);
        }
        /// <summary>
        /// method to display the vacancies table
        /// </summary>
        /// <returns></returns>
        /// 

        public IActionResult DisplayVacancies()
        {
           // log.Info("[DisplayVacancies]:Action Method returns view which displays the Locations Details");
          
            List<Vacancy> vacancy = _serviceVacancy.FindbyAll();
            return View(vacancy);
        }

        /// <summary>
        /// method to display the employee table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayEmployees()
        {
          //  log.Info("[DisplayEmployees]:Action Method returns view which displays the Locations Details");
            
            List<Employee> employee = _serviceEmployee.FindbyAll();
            return View(employee);
        }
        /// <summary>
        /// Method to Display Sources
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplaySources()
        {
           // log.Info("[DisplaySource]:Action Method returns view which displays the Locations Details");
            
            List<Source> source = _serviceSource.FindbyAll();
            return View(source);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
