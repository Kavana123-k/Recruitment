using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Recruit.Models;
using NLog;

namespace Recruit.DataAccessLayer
{
    public class VacancyEngine
    {

        public static Logger log;
        private IConfiguration Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public VacancyEngine(IConfiguration _configuration)
        {
            Configuration = _configuration;
            log = LogManager.GetCurrentClassLogger();
        }



        /// <summary>
        ///  method to get the value from tbl_locations
        /// </summary>
        /// <returns></returns>
        public List<Vacancy> FindByAll()
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");
            var data = new List<Vacancy>();
            
            try
            {
                using (IDbConnection database = new SqlConnection(connectionString))
                {

                    data = database.Query<Vacancy>(" SELECT code, name,vacancy FROM tbl_vacancies").ToList();
                }


            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
            }
            return (data);
        }

        public Vacancy FindByCode(string code)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new Vacancy();
            try
            {

                data = FindByAll().Where(records => records.code == code).FirstOrDefault();

            }
            catch (Exception exception)
            {
                log.Error("[FindByCode]:" + exception);
            }
            return data;
        }
        public String VacancyCRU(Vacancy Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            try
            {
                //if (FindByAll().Any(records => records.code == Entities.code) == false)
                if(string.IsNullOrWhiteSpace(Entities.code))
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string insertQuery = @"INSERT INTO tbl_vacancies([code],[name],[vacancy])VALUES (@code,@name,@vacancy)";

                        var result = database.Execute(insertQuery, new
                        {
                            Entities.code,
                            Entities.name,
                            Entities.vacancy

                        });
                    }
                    log.Info("[VacancyCRU]:Data save Successfully");
                    return ("Data save Successfully");
                }

                else
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string updateQuery = @"UPDATE tbl_vacancies SET name=@name,vacancy=@vacancy WHERE code=@code";

                        var result = database.Execute(updateQuery, new
                        {
                            Entities.code,
                            Entities.name,
                            Entities.vacancy
                        });
                    }
                    log.Info("[VacancyCRU]:Data save Successfully");
                    return ("Data Updated Successfully");
                }


            }
            catch (Exception exception)
            {

                log.Error("[VacancyCRU]:" + exception);
                return (exception.Message.ToString());
            }
        }
    }
}
