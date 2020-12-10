using System;
using Recruit.Models;
using Recruit.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class ProcessStageService
    {


        // public static Logger log;
        private IConfiguration _Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public ProcessStageService(IConfiguration _configuration)
        {
            _Configuration = _configuration;
            // log = LogManager.GetCurrentClassLogger();
        }

        public ProcessStage Findby(int id)
        {
            ProcessStageEngine processStageEngine = new ProcessStageEngine(_Configuration);

            return processStageEngine.FindById(id);
        }
        public List<ProcessStage> FindbyAll()
        {
            ProcessStageEngine processStageEngine = new ProcessStageEngine(_Configuration);

            return processStageEngine.FindByAll();
        }
        public string ProcessStageDetail(ProcessStage Entities)
        {
            ProcessStageEngine processStageEngine = new ProcessStageEngine(_Configuration);
            return processStageEngine.ProcessStageCRU(Entities);

        }

    }
}
