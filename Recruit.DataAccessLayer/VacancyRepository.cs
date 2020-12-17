using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;
using log4net;

namespace Recruit.DataAccessLayer
{
    public class VacancyRepository : IGenericRepository<Vacancy>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(VacancyRepository));


        IConnectionFactory _connectionFactory;
        public VacancyRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Method to perform INSERT operation 
        /// </summary>
        /// <param name="entity">the row value which has to be inserted</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        public string Add(Vacancy entity)
        {
            log.Info("[VacancyRepository][Add]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string insertQuery = @"INSERT INTO tbl_vacancies([code],[name],[vacancy])VALUES (@code,@name,@vacancy)";

                    var result = database.Execute(insertQuery, new
                    {
                        entity.code,
                        entity.name,
                        entity.vacancy

                    });
                }
                log.Info("[VacancyRepository][Add]:Data save Successfully");
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
               
              log.Error("[VacancyRepository][Add]:" + exception);
                return ("Insert Unsuccessful" + exception);
            }

        }
        /// <summary>
        /// Method to perform DELETE operation
        /// </summary>
        /// <param name="entity">value that has to be deleted</param>
        void IGenericRepository<Vacancy>.Delete(Vacancy entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to DISPLAY A SPECIFIC record from the specified table from the DB
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>The Row values for the specified Primary Key</returns>
        public Vacancy Get(int id)
        {
            log.Info("[VacancyRepository][Get]");
            var data = new Vacancy();
            try
            {
                data = GetAll().Where(records => records.id == id).FirstOrDefault();

            }
            catch (Exception exception)
            {
                log.Error("[VacancyRepository][Add]" + exception);
            }
            return data;
        }
        /// <summary>
        /// Method to perform DISPLAY Operation
        /// </summary>
        /// <returns>ALL the contents in the table from the DB</returns>
        public List<Vacancy> GetAll()
        {
            log.Info("[VacancyRepository][GetAll]");

            var data = new List<Vacancy>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    data = database.Query<Vacancy>(" SELECT id,code, name,vacancy FROM tbl_vacancies").ToList();
                }
            }
            catch (Exception exception)
            {
                log.Error("[VacancyRepository][GetAll]" + exception);
            }
            return data;


        }
        /// <summary>
        /// Method to Perform UPDATE operation
        /// </summary>
        /// <param name="entity">the row value which has to be Updated</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        string IGenericRepository<Vacancy>.Update(Vacancy entity)
        {
            log.Info("[VacancyRepository][Update]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string updateQuery = @"UPDATE tbl_vacancies SET code=@code,name=@name,vacancy=@vacancy WHERE id=@id";

                    var result = database.Execute(updateQuery, new
                    {
                        entity.id,
                        entity.code,
                        entity.name,
                        entity.vacancy
                    });
                }
                log.Info("[VacancyRepository][Update] : Data save Successfully");
                return ("Data Updated Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[VacancyRepository][Update]" + exception);
                return ("Update Unsuccessful" + exception);
            }

        }
    }
}


