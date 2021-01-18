using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class LocationService : IService<Location>
    {
        readonly IUnitOfWork _unitOfWork;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LocationService));
        
        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// BAL service Method to Get Specific Rows
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Contents of the Row that is Specified</returns>
        public Location FindBy(int id)
        {
            log.Info("[LocationService][FindBy]" + id);
            return _unitOfWork.locationRepository.Get(id);
        }
        /// <summary>
        /// BAL service Method to get all the Values from the table
        /// </summary>
        /// <returns>All the contents from the table</returns>
        public List<Location> FindbyAll()
        {
            log.Info("[LocationService][FindByAll]");
            return _unitOfWork.locationRepository.GetAll();
        }
        /// <summary>
        /// BAL service Method to INSERT
        /// </summary>
        /// <param name="Entity">Value that needs to be inserted</param>
        /// <returns>Message</returns>
        public string Insert(Location Entity)
        {
            log.Info("[LocationService][Insert]");
            return _unitOfWork.locationRepository.Add(Entity);
        }
        /// <summary>
        /// BAL service Method to UPDATE 
        /// </summary>
        /// <param name="Entity">Contetns that has to be updated</param>
        /// <returns></returns>
        public string Update(Location Entity)
        {
            log.Info("[LocationService][Update]");
            return _unitOfWork.locationRepository.Update(Entity);
        }
        /// <summary>
        /// BAL Service Method to DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// BAL Service Method to Display required
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Location> GetRequired(int id)
        {
            log.Info("[GetRequired]");
            throw new System.NotImplementedException();
        }
    }
}