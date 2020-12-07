using System;
using Recruit.Models;
using Recruit.DataAccessLayer;
using Microsoft.Extensions.Configuration;

namespace Recruit.BusinessAccessLayer
{
    public class CandidateService
    {

        // public static Logger log;
        private IConfiguration _Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public CandidateService(IConfiguration _configuration)
        {
            _Configuration = _configuration;
            // log = LogManager.GetCurrentClassLogger();
        }

        public Candidate Findby(int id)
        {
            CandidateEngine candidateEnglkine = new CandidateEngine(_Configuration);

            return candidateEnglkine.FindById(id);



        }
    }
}
