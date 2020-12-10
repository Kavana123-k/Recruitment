using System;
using Recruit.Models;
using Recruit.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class VacancyService
    {
       

            // public static Logger log;
            private IConfiguration _Configuration;


            ///// <summary>
            /// constructor for configuration to use connectionstring from appsettings.json
            /// </summary>
            /// <param name="_configuration"></param>
            public VacancyService(IConfiguration _configuration)
            {
                _Configuration = _configuration;
                // log = LogManager.GetCurrentClassLogger();
            }

            public Vacancy Findby(String code)
            {
                  VacancyEngine vacancyEngine = new VacancyEngine(_Configuration);

                return vacancyEngine.FindByCode(code);
            }
        public List<Vacancy> FindbyAll()
        {
            VacancyEngine vacancyEngine = new VacancyEngine(_Configuration);

            return vacancyEngine.FindByAll();
        }
        public string VacancyDetail(Vacancy Entities)
            {
                VacancyEngine vacancyEngine = new VacancyEngine(_Configuration);
                return vacancyEngine.VacancyCRU(Entities);

            }
        
    }
}
