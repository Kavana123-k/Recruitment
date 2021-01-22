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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Recruit.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(HomeController));

        /// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
       

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
        static Recruit.BusinessAccessLayer.Interface.IService<Timeline> _seviceTimeline;
        public HomeController(Recruit.BusinessAccessLayer.Interface.IService<Candidate> serviceCanidate,
                                Recruit.BusinessAccessLayer.Interface.IService<Location> serviceLocation,
                                Recruit.BusinessAccessLayer.Interface.IService<Employee> serviceEmployee,
                                Recruit.BusinessAccessLayer.Interface.IService<InterviewDetail> serviceInterviewDetail,
            Recruit.BusinessAccessLayer.Interface.IService<InterviewRoundStatus> serviceInterviewRoundStatus,
            Recruit.BusinessAccessLayer.Interface.IService<Owner> serviceOwner,
            Recruit.BusinessAccessLayer.Interface.IService<ProcessStatus> serviceProcessStatus,
            Recruit.BusinessAccessLayer.Interface.IService<ProcessStage> serviceProcessStage,
            Recruit.BusinessAccessLayer.Interface.IService<Vacancy> serviceVacancy,
            Recruit.BusinessAccessLayer.Interface.IService<Source> serviceSource,
            Recruit.BusinessAccessLayer.Interface.IService<Timeline> seviceTimeline
           )
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
            _seviceTimeline = seviceTimeline;


        }


        /// <summary>
        /// function to display the index play ie the dashboard
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            log.Info("[Index]:Action Method returns view which displays the Dashboard");
            return View();
        }

        /// <summary>
        /// Action Method returns view which displays the Candidates Details
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayCandidatesDetails()
        {
            log.Debug("[DisplayCandidatesDetails]: ");
            try
            {

                var data = _serviceCandidate.FindbyAll();
                return View(data);
            }
            catch (Exception exception)
            {
                log.Error("[InsertCandidatesDetails]:" + exception);
                return View();
            }

        }

        /// <summary>
        /// Method to display the page with forms to insert into interview details
        /// </summary>
        /// <returns>a view </returns>
        [HttpGet]
        public IActionResult InsertInterviewDetails(int id)
        {
            log.Info("[InsertInterviewDetails]:[Get]Action Method returns view which gets the page to insert the Interview Details [Data]=" + id);
            try
            {
               TempData["status"] = _serviceInterviewRoundStatus.FindbyAll();
                TempData["ProcessStages"] = _serviceProcessStage.FindbyAll();

                var interviewers = _serviceEmployee.FindbyAll();
                //   TempData["interviewers"] = new MultiSelectList(interviewers, "id", "name");
               TempData["interviewers"] = interviewers;
                //  TempData["AllLocations"] = GetAllLocations();

                // Candia.Preferred = new List<Location>();

                var interviewDetail = new InterviewDetail();
                
                if (id!=0)
                {
                    ViewBag.SubmitValue = "Update";
                    interviewDetail = _serviceInterviewDetail.FindBy(id);
                    return View(interviewDetail);

                }
                else
                {
                    ViewBag.SubmitValue = "Insert";
                    return View();
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertInterviewDetails]:" + exception);
                return View();
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
            try
            {
                TempData["status"] = _serviceInterviewRoundStatus.FindbyAll();
                TempData["ProcessStages"] = _serviceProcessStage.FindbyAll();
                var interviewers = _serviceEmployee.FindbyAll();
               TempData["interviewers"] = interviewers; //new MultiSelectList(interviewers, "id", "name");
              //  ViewBag.SubmitValue = "Insert";
                log.Info("[InsertInterviewDetails]:[Post]Action Method returns view which posts the input page to the table Interview Details ");
                if (entity.id == 0)
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            TempData["msg"] = _serviceInterviewDetail.Insert(entity);
                            //var y = _serviceInterviewer.Insert(entity.id, entity.candidate_id, entity.employee_id);
                            //if (x == "Data save Successfully" && y == "Data save Successfully") 
                            //{
                            //    TempData["msg"] = "Data saved Successfully";
                            //}
                        }
                    }
                    catch (Exception exception)
                    {
                        log.Error("[InsertInterviewDetails]:" + exception);
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
                        log.Error("[InsertInterviewDetails]:" + exception);
                        TempData["msg"] = exception.Message;
                    }

                }
            }

            catch (Exception exception)
            {
                log.Error("[InsertInterviewDetails]:" + exception);

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
            try
            {
                log.Info("[InsertCandidates]:[GET]Action Method returns view which gets thepage to insert the Interview Details [Data]=" + id);

                TempData["Sources"] = _serviceSource.FindbyAll();
                TempData["ProcessStages"] = _serviceProcessStage.FindbyAll();
                TempData["ProcessStatuses"] = _serviceProcessStatus.FindbyAll();
                TempData["Vacancies"] = _serviceVacancy.FindbyAll();
                TempData["Employees"] = _serviceEmployee.FindbyAll();
                TempData["Owners"] = _serviceOwner.FindbyAll();
                TempData["Locations"] = _serviceLocation.FindbyAll();

                var candidate = new Candidate();
                
                if (id!=0)
                {
                    ViewBag.SubmitValue = "Update";
                    candidate = _serviceCandidate.FindBy(id);
                    return View(candidate);

                }
                else
                {
                    ViewBag.SubmitValue = "Insert";
                    return View();
                }

            }
            catch (Exception exception)
            {
                log.Error("[InsertCandidates]:" + exception);
                return View();
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
            log.Info("[InsertCandidates]:[Post]Action Method returns view which posts the input page to the table Candidates Details");
            try
            {
                TempData["Sources"] = _serviceSource.FindbyAll();
                TempData["ProcessStages"] = _serviceProcessStage.FindbyAll();
                TempData["ProcessStatuses"] = _serviceProcessStatus.FindbyAll();
                TempData["Vacancies"] = _serviceVacancy.FindbyAll();
                TempData["Employees"] = _serviceEmployee.FindbyAll();
                TempData["Owners"] = _serviceOwner.FindbyAll();
                TempData["Locations"] = _serviceLocation.FindbyAll();
                if (entity.id == 0)
                {
                    try
                    {


                        if (ModelState.IsValid)
                        {

                            TempData["msg"] = _serviceCandidate.Insert(entity);


                            //  Storepreferredlocation(candId, entity.PreferredLoc);
                        }
                    }
                    catch (Exception exception)
                    {
                        log.Error("[InsertCandidates]:" + exception);
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
                        log.Error("[InsertCandidates]:" + exception);
                        TempData["msg"] = exception.Message;
                    }

                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertCandidates]:" + exception);
            }

            return View();
        }

        [HttpGet]
        public IActionResult InsertLocations(int id)
        {
            log.Info("[InsertLocations]:[GET]Action Method returns view which gets thepage to insert the Locations Details [Data]=" + id);
            TempData["Location"] = _serviceLocation.FindbyAll();
            try
            {
                var location = new Location();
              
                //if (!string.IsNullOrWhiteSpace(id.ToString()))
                //{
                //    location = _serviceLocation.FindBy(id);
                //    return View(location);

                //}
                //else
                //{
                //    locationAll = _serviceLocation.FindbyAll();
                //    return View(locationAll);
                //}

                if (id != 0)
                {
                    location = _serviceLocation.FindBy(id);
                    ViewBag.SubmitValue = "Update";
                    
                    return View(location);
                }
                else
                {
                    ViewBag.SubmitValue = "Insert";
                    
                    return View();
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertLocations]:" + exception);
                return View();
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

            log.Info("[InsertLocations]:[Post]Action Method returns view which posts the input page to the table Locations Details");
            TempData["Location"] = _serviceLocation.FindbyAll();
            try
            {
                if (entity.id == 0)
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            
                            //int code = _serviceLocation.Insert(entity);
                            //if(code==0)
                            //{
                            //    TempData["msg"] = "Data save Successfully";
                            //}
                            //else if(code==1)
                            //{
                            //    TempData["msg"] = "Data Entered is Already Present";
                            //}
                            //else if(code==2)
                            //{
                            //    TempData["msg"] = "Data Entered is Already Present";
                            //}
                            TempData["msg"] = _serviceLocation.Insert(entity);
                        }
                    }
                    catch (Exception exception)
                    {
                        log.Error("[InsertLocations]:" + exception);
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
                        log.Error("[InsertLocations]:" + exception);
                        TempData["msg"] = exception.Message;
                    }

                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertLocations]:" + exception);
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
            TempData["source"] = _serviceSource.FindbyAll();
            log.Info("[InsertSources]:[GET]Action Method returns view which gets the page to insert the table Sources Details [Data]=" + id);
            try
            {

                var source = new Source();
              
                if (id!=0)
                {
                    ViewBag.SubmitValue = "Update";
                    source = _serviceSource.FindBy(id);
                    return View(source);

                }
                else
                {
                    ViewBag.SubmitValue = "Insert";
                    return View();
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertSources]:" + exception);
                return View();

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
            TempData["source"] = _serviceSource.FindbyAll();

            log.Info("[InsertSources]:[Post]Action Method returns view which posts the input page to the table Sources Details");
            try
            {
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
                        log.Error("[InsertSources]:" + exception);
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
                        log.Error("[InsertSources]:" + exception);
                        TempData["msg"] = exception.Message;
                    }

                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertSources]:" + exception);
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
            log.Info("[InsertVacancies]:[GET]Action Method returns view which gets the page to insert the Vacancies Details [Data]=" + id);
            TempData["vacancy"]= _serviceVacancy.FindbyAll(); ;
            try
            {
                var vacancy = new Vacancy();
               
                if (id!=0)
                {
                    ViewBag.SubmitValue = "Update";
                    vacancy = _serviceVacancy.FindBy(id);
                    return View(vacancy);

                }
                else
                {
                    ViewBag.SubmitValue = "Insert";
                    return View();
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertVacancies]:" + exception);
                return View();

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

            log.Info("[InsertVacancies]:[Post]Action Method returns view which posts the input page to the table Vacancies Details");
            TempData["vacancy"]= _serviceVacancy.FindbyAll();
            try
            {
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
                        log.Error("[InsertVacancies]:" + exception);
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
                        log.Error("[InsertVacancies]:" + exception);
                        TempData["msg"] = exception.Message;
                    }

                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertVacancies]:" + exception);

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
            TempData["status"] = _serviceProcessStatus.FindbyAll();
            log.Info("[InsertProcessStatus]:[GET]Action Method returns view which gets the page to insert the Process Status Details [Data]=" + id);
            try
            {
                var processStatus = new ProcessStatus();
                
                if (id!=0)
                {
                    ViewBag.SubmitValue = "Update";
                    processStatus = _serviceProcessStatus.FindBy(id);
                    return View(processStatus);

                }
                else
                {
                    ViewBag.SubmitValue = "Insert";
                    return View();
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertProcessStatus]:" + exception);
                return View();
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
            TempData["status"] = _serviceProcessStatus.FindbyAll();
            log.Info("[InsertProcessStatus]:[Post]Action Method returns view which posts the input page to the table Process Status Details");
            try
            {
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
                        log.Error("[InsertProcessStatus]:" + exception);
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
                        log.Error("[InsertProcessStatus]:" + exception);
                        TempData["msg"] = exception.Message;
                    }

                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertProcessStatus]:" + exception);
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
            TempData["stage"] = _serviceProcessStage.FindbyAll();
            log.Info("[InsertProcessStages]:[GET]Action Method returns view which gets the page to insert the Process Stages Details [Data]=" + id);
            try
            {
                var processStage = new ProcessStage();
                
                if (id!=0)
                {
                    ViewBag.SubmitValue = "Update";
                    processStage = _serviceProcessStage.FindBy(id);
                    return View(processStage);

                }
                else
                {
                    ViewBag.SubmitValue = "Insert";
                    return View();
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertProcessStages]:" + exception);
                return View();
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
            TempData["stage"] = _serviceProcessStage.FindbyAll();
            try
            {
                if (entity.id == 0)
                {

                    log.Info("[InsertProcessStages]:[Post]Action Method returns view which posts the input page to the table Process Stages Details");
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            TempData["msg"] = _serviceProcessStage.Insert(entity);
                        }
                    }
                    catch (Exception exception)
                    {
                        log.Error("[InsertProcessStages]:" + exception);
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
                        log.Error("[InsertProcessStages]:" + exception);
                        TempData["msg"] = exception.Message;
                    }
                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertProcessStages]:" + exception);
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
            log.Info("[InsertInterviewRoundStatuses]:[GET]Action Method returns view which gets the page to insert the table Interview Round Statuses Details");
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
            try
            {
                if (entity.id == 0)
                {

                    log.Info("[InsertInterviewRoundStatuses]:[Post]Action Method returns view which posts the input page to the table Interview Round Statuses Details");
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            TempData["msg"] = _serviceInterviewRoundStatus.Insert(entity);
                        }
                    }
                    catch (Exception exception)
                    {
                        log.Error("[InsertInterviewRoundStatuses]:" + exception);
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
                        log.Error("[InsertInterviewRoundStatuses]:" + exception);
                        TempData["msg"] = exception.Message;
                    }

                }
            }
            catch (Exception exception)
            {
                log.Error("[InsertInterviewRoundStatuses]:" + exception);

            }

            return View();
        }
        /// <summary>
        /// Method to display interview details
        /// </summary>
        /// <returns>returns a list containing the details to the view </returns>
        public IActionResult DisplayInterviewDetails()
        {
            try
            {
                List<InterviewDetail> interviewDetails = _serviceInterviewDetail.FindbyAll();
               // TempData["interviewer"] = _serviceInterviewDetail.Findinterviewers();
                return View(interviewDetails);
            }
            catch (Exception exception)
            {
                log.Error("[DisplayInterviewDetails]:" + exception);
                return View();
            }

        }
        /// <summary>
        /// Method to display interview details
        /// </summary>
        /// <returns>returns a list containing the details to the view </returns>
        public JsonResult DisplayInterviewDetailsList()
        {
            try
            {
                List<InterviewDetail> interviewDetails = _serviceInterviewDetail.FindbyAll();
                // TempData["interviewer"] = _serviceInterviewDetail.Findinterviewers();
                return Json( interviewDetails);
            }
            catch (Exception exception)
            {
                log.Error("[DisplayInterviewDetails]:" + exception);
                return  Json( new List<InterviewDetail>());
            }

        }

        /// <summary>
        /// method to display the location table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayLocations()
        {

            log.Info("[DisplayLocations]:Action Method returns view which displays the Locations Details");
            try
            {
                List<Location> location = _serviceLocation.FindbyAll();
                return View(location);
            }

            catch (Exception exception)
            {
                log.Error("[DisplayLocations]:" + exception);
                return View();
            }
        }
        /// <summary>
        /// method to display the location table
        /// </summary>
        /// <returns></returns>
        public JsonResult GetLocations()
        {

            log.Info("[DisplayLocations]:Action Method returns view which displays the Locations Details");
            try
            {
                List<Location> location = _serviceLocation.FindbyAll();
                return Json(location);
            }

            catch (Exception exception)
            {
                log.Error("[DisplayLocations]:" + exception);
                return Json("");
            }
        }

        /// <summary>
        /// method to display the Process Statuses table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayProcessStatus()
        {
           log.Info("[DisplayProcessStatus]:Action Method returns view which displays the Locations Details");
            try
            {
                List<ProcessStatus> processStatus = _serviceProcessStatus.FindbyAll();
                return View(processStatus);
            }
            catch (Exception exception)
            {
                log.Error("[DisplayProcessStatus]:" + exception);
                return View();
            }
        }
        /// <summary>
        /// method to display the process stages table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayProcessStages()
        {
            log.Info("[DisplayProcessStages]:Action Method returns view which displays the Locations Details");
            try
            {
                List<ProcessStage> processStage = _serviceProcessStage.FindbyAll();
                return View(processStage);
            }
            catch (Exception exception)
            {
                log.Error("[DisplayProcessStages]:" + exception);
                return View();
            }
        }
        /// <summary>
        /// method to display the vacancies table
        /// </summary>
        /// <returns></returns>
        /// 

        public IActionResult DisplayVacancies()
        {
          log.Info("[DisplayVacancies]:Action Method returns view which displays the Locations Details");
            try
            {
                List<Vacancy> vacancy = _serviceVacancy.FindbyAll();
                return View(vacancy);
            }
            catch (Exception exception)
            {
                log.Error("[DisplayVacancies]:" + exception);
                return View();
            }
        }

        /// <summary>
        /// method to display the employee table
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplayEmployees()
        {
            log.Info("[DisplayEmployees]:Action Method returns view which displays the Locations Details");
            try
            {
                List<Employee> employee = _serviceEmployee.FindbyAll();
                return View(employee);
            }
            catch (Exception exception)
            {
                log.Error("[DisplayEmployees]:" + exception);
                return View("");
            }
        }
        /// <summary>
        /// method to display the employee table
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEmployees()
        {
            log.Info("[DisplayEmployees]:Action Method returns view which displays the Locations Details");
            try
            {
                List<Employee> employee = _serviceEmployee.FindbyAll();
                return Json(employee);
            }
            catch (Exception exception)
            {
                log.Error("[DisplayEmployees]:" + exception);
                return Json("");
            }
        }
        /// <summary>
        /// Method to Display Sources
        /// </summary>
        /// <returns></returns>
        public IActionResult DisplaySources()
        {
            log.Info("[DisplaySource]:Action Method returns view which displays the Locations Details");
            try
            {
                List<Source> source = _serviceSource.FindbyAll();
                return View(source);
            }
            catch (Exception exception)
            {
                log.Error("[DisplaySource]:" + exception);
                return View();
            }
        }
       /// <summary>
       /// Method to display individual interviewdetails
       /// </summary>
       /// <returns></returns>
       public IActionResult DisplaySpecificInterviewDetails(int id)
        {
          List<Timeline> timeline = _seviceTimeline.GetRequired(id);
            return View(timeline);
        }
        /// <summary>
        /// Method to display the page with forms to insert into interview details
        /// </summary>
        /// <returns>a view </returns>
        [HttpGet]
        public IActionResult InsertSpecificInterviewDetails(int id)
        {
            log.Info("[InsertInterviewDetails]:[Get]Action Method returns view which gets the page to insert the Interview Details [Data]=" + id);
            try
            {
                TempData["status"] = _serviceInterviewRoundStatus.FindbyAll();
                TempData["ProcessStages"] = _serviceProcessStage.FindbyAll();
                TempData["Candidate_id"] = id;

                var interviewers = _serviceEmployee.FindbyAll();

              //  var data = new MultiSelectList(interviewers, "id", "name");
                TempData["interviewers"] = interviewers;
                //  TempData["AllLocations"] = GetAllLocations();

                // Candia.Preferred = new List<Location>();
                var items = (_seviceTimeline.GetRequired(id)); 
                var Detail = new InterviewDetail();
               var i= items.Where(c => c.candidate_id == id);
                Detail = (InterviewDetail)i;
                var interviewDetails = new InterviewDetail();

                ViewBag.SubmitValue = "Add";
                    interviewDetails.candidate_id = id;
                interviewDetails.first_name = Detail.first_name;



                return View(interviewDetails);

               
            }
            catch (Exception exception)
            {
                log.Error("[InsertInterviewDetails]:" + exception);
                return View();
            }

        }

        /// <summary>
        /// method used to post the inputs to the interview details table
        /// </summary>
        /// <param name="employeeEntities"></param>
        /// <returns>a view</returns>
        [HttpPost]
        public IActionResult InsertSpecificInterviewDetails([Bind] InterviewDetail entity)
        {
            try
            {
                TempData["status"] = _serviceInterviewRoundStatus.FindbyAll();
                TempData["ProcessStages"] = _serviceProcessStage.FindbyAll();
                TempData["Candidate_id"] = entity.candidate_id;
                var interviewers = _serviceEmployee.FindbyAll();
                
                 // var data= new MultiSelectList(interviewers, "id", "name");
                TempData["interviewers"] = interviewers;
                log.Info("[InsertInterviewDetails]:[Post]Action Method returns view which posts the input page to the table Interview Details ");
                if (entity.id == 0)
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            TempData["msg"] = _serviceInterviewDetail.Insert(entity);
                            //var y = _serviceInterviewer.Insert(entity.id, entity.candidate_id, entity.employee_id);
                            //if (x == "Data save Successfully" && y == "Data save Successfully") 
                            //{
                            //    TempData["msg"] = "Data saved Successfully";
                            //}
                        }
                    }
                    catch (Exception exception)
                    {
                        log.Error("[InsertInterviewDetails]:" + exception);
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
                        log.Error("[InsertInterviewDetails]:" + exception);
                        TempData["msg"] = exception.Message;
                    }

                }
            }

            catch (Exception exception)
            {
                log.Error("[InsertInterviewDetails]:" + exception);

            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View();
        }
    }
}
