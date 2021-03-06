﻿using Recruit.DataAccessLayer.Interface;
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
    public class ProcessStageRepository : IGenericRepository<ProcessStage>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ProcessStageRepository));


        IConnectionFactory _connectionFactory;
        public ProcessStageRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Method to perform INSERT operation 
        /// </summary>
        /// <param name="entity">the row value which has to be inserted</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        public string Add(ProcessStage entity)
        {
            log.Info("[ProcessStageRepository][Add]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string insertQuery = @"INSERT INTO tbl_process_stages([code],[stage])VALUES (@code,@stage)";

                    var result = database.Execute(insertQuery, new
                    {
                        entity.code,
                        entity.stage
                    });
                }
                log.Info("[ProcessStageRepository][Add]:Data save Successfully");
                //return 0;
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[ProcessStageRepository][Add]:" + exception);
                //if ((exception.Message).Contains("Violation of UNIQUE KEY constraint 'UK_tbl_locations_city'"))
                //{
                //    //return 1;
                //    return ("Insert Unsuccessful " + exception.Message);
                //}
                return ("Insert Unsuccessful " + exception.Message);
            }

        }
        /// <summary>
        /// Method to perform DELETE operation
        /// </summary>
        /// <param name="entity">value that has to be deleted</param>
        void IGenericRepository<ProcessStage>.Delete(ProcessStage entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to DISPLAY A SPECIFIC record from the specified table from the DB
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>The Row values for the specified Primary Key</returns>
        public ProcessStage Get(int id)
        {
            log.Info("[ProcessStageRepository][Get]");
            var data = new ProcessStage();
            try
            {
                data = GetAll().Where(records => records.id == id).FirstOrDefault();
            }
            catch (Exception exception)
            {
                log.Error("[ProcessStageRepository][Get]"+exception);
            }
            return data;
        }
        /// <summary>
        /// Method to perform DISPLAY Operation
        /// </summary>
        /// <returns>ALL the contents in the table from the DB</returns>
        public List<ProcessStage> GetAll()
        {
            log.Info("[ProcessStageRepository][GetAll]");
            
            var data = new List<ProcessStage>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    data = database.Query<ProcessStage>(" SELECT id,code,stage FROM tbl_process_stages").ToList();
                }
            }
            catch (Exception exception)
            {
                 log.Error("[ProcessStageRepository][Add]:" + exception);
            }
            return data;


        }
        /// <summary>
        /// Method to Perform UPDATE operation
        /// </summary>
        /// <param name="entity">the row value which has to be Updated</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        string IGenericRepository<ProcessStage>.Update(ProcessStage entity)
        {
            log.Info("[ProcessStageRepository][Update]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string updateQuery = @"UPDATE tbl_process_stages SET code=@code,stage=@stage WHERE id=@id";

                    var result = database.Execute(updateQuery, new
                    {
                        entity.id,
                        entity.code,
                        entity.stage,

                    });
                }
               log.Info("[ProcessStageRepository][Update]:Data save Successfully");
                //return 2;
                return ("Data Updated Successfully");
            }
            catch (Exception exception)
            {
                //if ((exception.Message).Contains("Violation of UNIQUE KEY constraint 'UK_tbl_locations_city'"))
                //{
                //    //return 3;
                //    return ("Insert Unsuccessful " + exception.Message);
                //}
                log.Error("[ProcessStageRepository][Update]:" + exception);
                return ("Update Unsuccessful " + exception.Message);
            }

        }
        /// <summary>
        /// Method to get required details
        /// </summary>
        /// <param name="entity"></param>

        public List<ProcessStage> GetRequired(int Id)
        {
            throw new NotImplementedException();
        }
    }
}


