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
    public class ProcessStatusRepository : IGenericRepository<ProcessStatus>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ProcessStatusRepository));


        IConnectionFactory _connectionFactory;
        public ProcessStatusRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Method to perform INSERT operation 
        /// </summary>
        /// <param name="entity">the row value which has to be inserted</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        public string Add(ProcessStatus entity)
        {
            log.Info("[ProcessStatusRepository][Add]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string insertQuery = @"INSERT INTO tbl_process_statuses([code],[status],[colour])VALUES (@code,@status,@colour)";
                    var result = database.Execute(insertQuery, new
                    {
                        entity.code,
                        entity.status,
                        entity.colour

                    });
                }
                log.Info("[ProcessStatusRepository][Add]:Data save Successfully");
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[ProcessStatusRepository][Add]:" + exception);
                return ("Insert Unsuccessful " + exception.Message);
            }

        }
        /// <summary>
        /// Method to perform DELETE operation
        /// </summary>
        /// <param name="entity">value that has to be deleted</param>
        void IGenericRepository<ProcessStatus>.Delete(ProcessStatus entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to DISPLAY A SPECIFIC record from the specified table from the DB
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>The Row values for the specified Primary Key</returns>
        public ProcessStatus Get(int id)
        {
            log.Info("[ProcessStatusRepository][Get]");
            var data = new ProcessStatus();
            try
            {
                data = GetAll().Where(records => records.id == id).FirstOrDefault();
            }
            catch (Exception exception)
            {
                log.Error("[ProcessStatusRepository][Get]"+exception);
            }
            return data;
        }
        /// <summary>
        /// Method to perform DISPLAY Operation
        /// </summary>
        /// <returns>ALL the contents in the table from the DB</returns>
        public List<ProcessStatus> GetAll()
        {
            log.Info("[ProcessStatusRepository][GetAll]");
            var data = new List<ProcessStatus>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    data = database.Query<ProcessStatus>("SELECT id,code,status,colour FROM tbl_process_statuses").ToList();
                }
            }
            catch (Exception exception)
            {
                 log.Error("[ProcessStatusRepository][GetAll]" + exception);
            }
            return data;


        }
        /// <summary>
        /// Method to Perform UPDATE operation
        /// </summary>
        /// <param name="entity">the row value which has to be Updated</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        string IGenericRepository<ProcessStatus>.Update(ProcessStatus entity)
        {
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string updateQuery = @"UPDATE tbl_process_statuses SET status=@status,colour=@colour WHERE id=@id";

                    var result = database.Execute(updateQuery, new
                    {
                        entity.id,
                        entity.code,
                        entity.status,
                        entity.colour
                    });
                }
                 log.Info("[ProcessStatusRepository][GetAll]:Data save Successfully");
                return ("Data Updated Successfully");
            }
            catch (Exception exception)
            {
                
                  log.Error("[ProcessStatusRepository][GetAll]" + exception);
                return ("Update Unsuccessful " + exception.Message);
            }

        }
        /// <summary>
        /// Method to get required details
        /// </summary>
        /// <param name="entity"></param>

        public List<ProcessStatus> GetRequired(int Id)
        {
            throw new NotImplementedException();
        }
    }
}


