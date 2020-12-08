using System;
using Recruit.Models;
using Recruit.DataAccessLayer;
using Microsoft.Extensions.Configuration;

namespace Recruit.BusinessAccessLayer
{
    public class LocationService
    {

        // public static Logger log;
        private IConfiguration _Configuration;


        ///// <summary>
        /// constructor for configuration to use connectionstring from appsettings.json
        /// </summary>
        /// <param name="_configuration"></param>
        public LocationService(IConfiguration _configuration)
        {
            _Configuration = _configuration;
            // log = LogManager.GetCurrentClassLogger();
        }

        public Location Findby(int id)
        {
            LocationEngine LocationEngine = new LocationEngine(_Configuration);

            return LocationEngine.FindById(id);
        }
        public string LocationDetails(Location Entities)
        {
            LocationEngine LocationEngine = new LocationEngine(_Configuration);
            return LocationEngine.LocationCRU(Entities);

        }
    }
}