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
    public class OwnerRepository : IGenericRepository<Owner>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(OwnerRepository));


        IConnectionFactory _connectionFactory;
        public OwnerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Method to perform INSERT operation 
        /// </summary>
        /// <param name="entity">the row value which has to be inserted</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        public string Add(Owner entity)
        {
            log.Info("[OwnerRepository][Add]");
            
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string insertQuery = @"INSERT INTO tbl_locations([first_name],[last_name])VALUES (first_name,@last_name)";
                    var result = database.Execute(insertQuery, new
                    {
                        entity.first_name,
                        entity.last_name
                    });
                }
                log.Info("[OwnerRepository][Add]:Data save Successfully");
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
               log.Error("[OwnerRepository][Add]:" + exception);
                return ("Insert Unsuccessful" + exception);
            }

        }
        /// <summary>
        /// Method to perform DELETE operation
        /// </summary>
        /// <param name="entity">value that has to be deleted</param>
        void IGenericRepository<Owner>.Delete(Owner entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to DISPLAY A SPECIFIC record from the specified table from the DB
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>The Row values for the specified Primary Key</returns>
        public Owner Get(int id)
        {
            var data = new Owner();
            try
            {
                data = GetAll().Where(records => records.id == id).FirstOrDefault();
            }
            catch (Exception exception)
            {
                log.Error("[OwnerRepository][Get]:" + exception);
            }
            return data;
        }
        /// <summary>
        /// Method to perform DISPLAY Operation
        /// </summary>
        /// <returns>ALL the contents in the table from the DB</returns>
        public List<Owner> GetAll()
        {

          log.Info("[OwnerRepository][GetAll]");
            var data = new List<Owner>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    data = database.Query<Owner>(" SELECT id,first_name,last_name FROM tbl_owners").ToList();
                }
            }
            catch (Exception exception)
            {
             log.Error("[OwnerRepository][GetAll]:" + exception);
            }
            return data;


        }
        /// <summary>
        /// Method to Perform UPDATE operation
        /// </summary>
        /// <param name="entity">the row value which has to be Updated</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        string IGenericRepository<Owner>.Update(Owner entity)
        {
            log.Info("[OwnerRepository][Update]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string updateQuery = @"UPDATE tbl_locations SET first_name=@first_name,last_name=@last_name WHERE id=@id";

                    var result = database.Execute(updateQuery, new
                    {
                        entity.id,
                        entity.first_name,
                        entity.last_name
                    });
                }
                log.Info("[OwnerRepository][Update]:Data save Successfully");
                return ("Data Updated Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[OwnerRepository][Update]:" + exception);
                return ("Update Unsuccessful" + exception);
            }

        }
    }
}


