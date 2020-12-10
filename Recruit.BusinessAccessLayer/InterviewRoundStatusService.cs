using System;
using Recruit.Models;
using Recruit.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class InterviewRoundStatusService
    {

        // public static Logger log;
        private IConfiguration _Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public InterviewRoundStatusService(IConfiguration _configuration)
        {
            _Configuration = _configuration;
            // log = LogManager.GetCurrentClassLogger();
        }

        public InterviewRoundStatus Findby(int id)
        {
            InterviewRoundStatusEngine interviewRoundStatusEngine = new InterviewRoundStatusEngine(_Configuration);

            return interviewRoundStatusEngine.FindById(id);
        }
        public List<InterviewRoundStatus> FindbyAll()
        {
            InterviewRoundStatusEngine interviewRoundStatusEngine = new InterviewRoundStatusEngine(_Configuration);

            return interviewRoundStatusEngine.FindByAll();
        }
        public string InterviewRoundStatusDetail(InterviewRoundStatus Entities)
        {
            InterviewRoundStatusEngine interviewRoundStatusEngine = new InterviewRoundStatusEngine(_Configuration);
            return interviewRoundStatusEngine.InterviewRoundStatusEngineCRU(Entities);

        }
    }
}