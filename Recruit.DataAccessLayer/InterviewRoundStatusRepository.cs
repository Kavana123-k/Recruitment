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
    public class InterviewRoundStatusRepository : IGenericRepository<InterviewRoundStatus>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(InterviewRoundStatusRepository));


        IConnectionFactory _connectionFactory;
        public InterviewRoundStatusRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Method to perform INSERT operation 
        /// </summary>
        /// <param name="entity">the row value which has to be inserted</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        public string Add(InterviewRoundStatus entity)
        {
            log.Info("[InterviewRoundStatusRepository][Add]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string insertQuery = @"INSERT INTO tbl_interview_round_statuses([status])VALUES (@status)";

                    var result = database.Execute(insertQuery, new
                    {
                      
                        entity.status

                    });
                }
                log.Info("[InterviewRoundStatusRepository][Add]:Data save Successfully");
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
              log.Error("[InterviewRoundStatusRepository][Add]:" + exception);
                return ("Insert Unsuccessful" + exception);
            }

        }
        /// <summary>
        /// Method to perform DELETE operation
        /// </summary>
        /// <param name="entity">value that has to be deleted</param>
        void IGenericRepository<InterviewRoundStatus>.Delete(InterviewRoundStatus entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to DISPLAY A SPECIFIC record from the specified table from the DB
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>The Row values for the specified Primary Key</returns>
        public InterviewRoundStatus Get(int id)
        {
            log.Info("[InterviewRoundStatusRepository][Get]");
            var data = new InterviewRoundStatus();
            try
            {
                data = GetAll().Where(records => records.id == id).FirstOrDefault();
            }
            catch (Exception exception)
            {
                log.Error("[InterviewRoundStatusRepository][Get]:" + exception);
            }
            return data;
        }
        /// <summary>
        /// Method to perform DISPLAY Operation
        /// </summary>
        /// <returns>ALL the contents in the table from the DB</returns>
        public List<InterviewRoundStatus> GetAll()
        {
            log.Info(" [InterviewRoundStatusRepository][GetAll]");

            var data = new List<InterviewRoundStatus>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    data = database.Query<InterviewRoundStatus>(" SELECT id,status FROM tbl_interview_round_statuses").ToList();
                }
            }
            catch (Exception exception)
            {
                log.Error("[InterviewRoundStatusRepository][GetAll]:" + exception);
            }
            return data;


        }
        /// <summary>
        /// Method to Perform UPDATE operation
        /// </summary>
        /// <param name="entity">the row value which has to be Updated</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        string IGenericRepository<InterviewRoundStatus>.Update(InterviewRoundStatus entity)
        {
            log.Info("[InterviewRoundStatusRepository][Update]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string updateQuery = @"UPDATE tbl_interview_round_statuses SET status=@status WHERE id=@id";

                    var result = database.Execute(updateQuery, new
                    {
                        entity.id,
                        entity.status
                    });
                }
               log.Info("[InterviewRoundStatusRepository][Update]:Data save Successfully");
                return ("Data Updated Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[InterviewRoundStatusRepository][Update]:" + exception);
                return ("Update Unsuccessful" + exception);
            }

        }
    }
}


