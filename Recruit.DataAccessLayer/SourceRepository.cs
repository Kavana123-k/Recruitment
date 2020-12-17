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
    public class SourceRepository : IGenericRepository<Source>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SourceRepository));


        IConnectionFactory _connectionFactory;
        public SourceRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Method to perform INSERT operation 
        /// </summary>
        /// <param name="entity">the row value which has to be inserted</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        public string Add(Source entity)
        {
            log.Info("[SourceRepository][Add]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string insertQuery = @"INSERT INTO tbl_sources([code],[name])VALUES (@code,@name)";

                    var result = database.Execute(insertQuery, new
                    {
                        entity.code,
                        entity.name

                    });
                }
                log.Info("[SourceRepository][Add]:Data save Successfully");
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[SourceRepository][Add]" + exception);
                return ("Insert Unsuccessful" + exception);
            }

        }
        /// <summary>
        /// Method to perform DELETE operation
        /// </summary>
        /// <param name="entity">value that has to be deleted</param>
        void IGenericRepository<Source>.Delete(Source entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to DISPLAY A SPECIFIC record from the specified table from the DB
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>The Row values for the specified Primary Key</returns>
        public Source Get(int id)
        {
            log.Info("[SourceRepository][Get]");
            var data = new Source();
            try
            {
             data = GetAll().Where(records => records.id == id).FirstOrDefault();
            }
            catch (Exception exception)
            {
                log.Error("[SourceRepository][Get]" + exception);
            }
            return data;
        }
        /// <summary>
        /// Method to perform DISPLAY Operation
        /// </summary>
        /// <returns>ALL the contents in the table from the DB</returns>
        public List<Source> GetAll()
        {

            log.Info("[SourceRepository][GetAll]");
          
            var data = new List<Source>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    data = database.Query<Source>("SELECT id,code,name FROM tbl_sources").ToList();
                }
            }
            catch (Exception exception)
            {
                 log.Error("[SourceRepository][GetAll]" + exception);
            }
            return data;


        }
        /// <summary>
        /// Method to Perform UPDATE operation
        /// </summary>
        /// <param name="entity">the row value which has to be Updated</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        string IGenericRepository<Source>.Update(Source entity)
        {
            log.Info("[SourceRepository][Update]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string updateQuery = @"UPDATE tbl_sources SET code=@code, name=@name WHERE id=@id ";

                    var result = database.Execute(updateQuery, new
                    {
                        entity.id,
                        entity.code,
                        entity.name
                    });
                }
                log.Info("[SourceRepository][Update]:Data save Successfully");
                return ("Data Updated Successfully");
            }
            catch (Exception exception)
            {
                 log.Error("[SourceRepository][Update]:" + exception);
                return ("Update Unsuccessful" + exception);
            }

        }
    }
}


