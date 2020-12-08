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
    public class LocationEngine
    {
      
            public static Logger log;
            private IConfiguration Configuration;


            ///// <summary>
            /// constructor for configuration to use connectionstring from appsettings.json
            /// </summary>
            /// <param name="_configuration"></param>
            public LocationEngine(IConfiguration _configuration)
            {
                Configuration = _configuration;
                log = LogManager.GetCurrentClassLogger();
            }


          
            /// <summary>
            ///  method to get the value from tbl_locations
            /// </summary>
            /// <returns></returns>
            public List<Location> FindByAll()
            {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

                  var data = new List<Location>();
                try
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        data = database.Query<Location>(" SELECT id,city FROM tbl_locations").ToList();
                    }

                }
                catch (Exception exception)
                {
                    log.Error(exception.Message);
                }
                return (data);
            }
        public Location FindById(int id)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            var data = new Location();
            try
            {

                data = FindByAll().Where(records => records.id == id).FirstOrDefault();

            }
            catch (Exception exception)
            {
                log.Error("[FindById]:" + exception);
            }
            return data;
        }
        public String LocationCRU(Location Entities)
        {
            String connectionString = this.Configuration.GetConnectionString("MyConn");

            try
            {
                //if (FindByAll().Any(records => records.id == Entities.id) == false)
                if(Entities.id==0)
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string insertQuery = @"INSERT INTO tbl_locations([city])VALUES (@city)";

                        var result = database.Execute(insertQuery, new
                        {
                            Entities.city

                        });
                    }
                    log.Info("[LocationCRU]:Data save Successfully");
                    return ("Data save Successfully");
                }
                else
                {
                    using (IDbConnection database = new SqlConnection(connectionString))
                    {
                        string updateQuery = @"UPDATE tbl_locations SET city=@city WHERE id=@id";

                        var result = database.Execute(updateQuery, new
                        {
                            Entities.id,
                            Entities.city
                        });
                    }
                    log.Info("[LocationCRU]:Data save Successfully");
                    return ("Data Updated Successfully");
                }


            }
            catch (Exception exception)
            {

                log.Error("[LocationCRU]:" + exception);
                return (exception.Message.ToString());
            }
        }
    }
}
