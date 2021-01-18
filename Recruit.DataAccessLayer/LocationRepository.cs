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
    public class LocationRepository : IGenericRepository<Location>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LocationRepository));


        IConnectionFactory _connectionFactory;
        public LocationRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Method to perform INSERT operation 
        /// </summary>
        /// <param name="entity">the row value which has to be inserted</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
       public string Add(Location entity)
        {
            log.Info("[LocationRepository][Add]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string insertQuery = @"INSERT INTO tbl_locations([city])VALUES (@city)";
                    var result = database.Execute(insertQuery, new
                    {
                        entity.city
                     });
                }
                log.Info("[LocationRepository][Add]:Data save Successfully");
               // return 0;
                return ("\n\n Data save Successfully");
            }
            catch (Exception exception)
            {
                 
                log.Error("[LocationRepository][Add]:" + exception);
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
        void IGenericRepository<Location>.Delete(Location entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to DISPLAY A SPECIFIC record from the specified table from the DB
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>The Row values for the specified Primary Key</returns>
       public Location Get(int id)
        {
            log.Info("[LocationRepository][Get]");
            var data = new Location() ;
            try
            {
                data= GetAll().Where(records => records.id == id).FirstOrDefault();
            }
            catch(Exception exception)
            {
                log.Error("[LocationRepository][Get]:" + exception);
            }
            return data;
        }
        /// <summary>
        /// Method to perform DISPLAY Operation
        /// </summary>
        /// <returns>ALL the contents in the table from the DB</returns>
       public List<Location> GetAll()
        {

            log.Info("[LocationRepository][GetAll]");
            var data = new List<Location>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    data = database.Query<Location>(" SELECT id,city FROM tbl_locations").ToList();
                }
            }
            catch (Exception exception)
            {
                log.Error("[LocationRepository][GetAll]:" + exception);
            }
            return data;


        }
        /// <summary>
        /// Method to Perform UPDATE operation
        /// </summary>
        /// <param name="entity">the row value which has to be Updated</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        string IGenericRepository<Location>.Update(Location entity)
        {
            log.Info("[LocationRepository][Update]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string updateQuery = @"UPDATE tbl_locations SET city=@city WHERE id=@id";

                    var result = database.Execute(updateQuery, new
                    {
                        entity.id,
                        entity.city
                    });
                }
                log.Info("[LocationRepository][Update]:Data save Successfully");
                // return 2;
                return ("Data Updated Successfully");
            }
            catch (Exception exception)
            {
                 log.Error("[LocationRepository][Update]:" + exception);
                //if ((exception.Message).Contains("Violation of UNIQUE KEY constraint 'UK_tbl_locations_city'"))
                //{
                //    //return 3;
                //    return ("Update Unsuccessful " + exception.Message);
                //}
                //return ("update Unsuccessful " + exception.Message);
                return ("Update Unsuccessful " + exception.Message);
            }

        }
        /// <summary>
        /// Method to get required details
        /// </summary>
        /// <param name="entity"></param>

        public List<Location> GetRequired(int Id)
        {
            throw new NotImplementedException();
        }
    }
}


