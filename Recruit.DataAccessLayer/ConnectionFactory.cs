using Microsoft.Extensions.Configuration;
using Recruit.DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Recruit.DataAccessLayer
{
    public class ConnectionFactory : IConnectionFactory
    {
        
        //private IConfiguration Configuration;
         
        //public ConnectionFactory(IConfiguration _configuration)
        //{
        //    Configuration = _configuration;
            
        //}
      
        public IDbConnection GetConnection
        {
            get
            {
                DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);

                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                //  conn.ConnectionString = this.Configuration.GetConnectionString("MyConn");
                conn.ConnectionString = "Data Source = DESKTOP-T3N0J77; Initial Catalog = Recruitment; Integrated Security = True";
                conn.Open();
                return conn;
            }
        }

        
    }
}
