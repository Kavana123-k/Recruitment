using System;
using Recruit.Models;
using Recruit.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class InterviewDetailService
    {


        // public static Logger log;
        private IConfiguration _Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public InterviewDetailService(IConfiguration _configuration)
        {
            _Configuration = _configuration;
            // log = LogManager.GetCurrentClassLogger();
        }

        public InterviewDetail Findby(int id)
        {
            InterviewDetailEngine interviewDetailEngine = new InterviewDetailEngine(_Configuration);

            return interviewDetailEngine.FindById(id);
        }
        public List<InterviewDetail> FindbyAll()
        {
            InterviewDetailEngine interviewDetailEngine = new InterviewDetailEngine(_Configuration);

            return interviewDetailEngine.FindByAll();
        }
        public string InterviewDetail(InterviewDetail Entities)
        {
            InterviewDetailEngine interviewDetailEngine = new InterviewDetailEngine(_Configuration);
            return interviewDetailEngine.InterviewDetailCRU(Entities);

        }

    }
}
