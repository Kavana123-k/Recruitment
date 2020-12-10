using System;
using Recruit.Models;
using Recruit.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class ProcessStatusService
    {


        // public static Logger log;
        private IConfiguration _Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public ProcessStatusService(IConfiguration _configuration)
        {
            _Configuration = _configuration;
            // log = LogManager.GetCurrentClassLogger();
        }

        public ProcessStatus Findby(int id)
        {
            ProcessStatusEngine ProcessStatusEngine = new ProcessStatusEngine(_Configuration);

            return ProcessStatusEngine.FindById(id);
        }
        public List<ProcessStatus> FindbyAll()
        {
            ProcessStatusEngine processStatusEngine = new ProcessStatusEngine(_Configuration);

            return processStatusEngine.FindByAll();
        }
        public string ProcessStatusDetail(ProcessStatus Entities)
        {
            ProcessStatusEngine ProcessStatusEngine = new ProcessStatusEngine(_Configuration);
            return ProcessStatusEngine.ProcessStatusCRU(Entities);

        }

    }
}
