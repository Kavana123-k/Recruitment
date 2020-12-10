using System;
using Recruit.Models;
using Recruit.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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
            CandidateEngine candidateEngine = new CandidateEngine(_Configuration);

            return candidateEngine.FindById(id);
        }
        public List<Candidate> FindbyAll()
        {
            CandidateEngine candidateEngine = new CandidateEngine(_Configuration);

            return candidateEngine.FindByAll();
        }
        public string CandidateDetail(Candidate Entities)
        {
            CandidateEngine candidateEngine = new CandidateEngine(_Configuration);
            return candidateEngine.CandidateCRU(Entities);

        }
    }
}