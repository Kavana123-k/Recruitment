using System;
using Recruit.Models;
using Recruit.DataAccessLayer;
using Microsoft.Extensions.Configuration;

namespace Recruit.BusinessAccessLayer
{
    public class SourceService
    {

        // public static Logger log;
        private IConfiguration _Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public SourceService(IConfiguration _configuration)
        {
            _Configuration = _configuration;
            // log = LogManager.GetCurrentClassLogger();
        }

        public Source Findby(String code)
        {
            SourceEngine sourceEngine = new SourceEngine(_Configuration);

            return sourceEngine.FindByCode(code);
        }
        public string SourceDetail(Source Entities)
        {
            SourceEngine sourceEngine = new SourceEngine(_Configuration);
            return sourceEngine.SourceCRU(Entities);

        }
    }
}