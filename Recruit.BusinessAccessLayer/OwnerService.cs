using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class OwnerService : IService<Owner>
    {
        readonly IUnitOfWork _unitOfWork;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(OwnerService));


        public OwnerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// BAL service Method to Get Specific Rows
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Contents of the Row that is Specified</returns>
        public Owner FindBy(int id)
        {
            log.Info("[OwnerService][FindBy]" + id);
            return _unitOfWork.ownerRepository.Get(id);
        }
        /// <summary>
        /// BAL service Method to get all the Values from the table
        /// </summary>
        /// <returns>All the contents from the table</returns>
        public List<Owner> FindbyAll()
        {
            log.Info("[OwnerService][FindByAll]");
            return _unitOfWork.ownerRepository.GetAll();
        }
        /// <summary>
        /// BAL service Method to INSERT
        /// </summary>
        /// <param name="Entity">Value that needs to be inserted</param>
        /// <returns>Message</returns>
        public string Insert(Owner Entity)
        {
            log.Info("[OwnerService][Insert]");
            return _unitOfWork.ownerRepository.Add(Entity);
        }
        /// <summary>
        /// BAL service Method to UPDATE 
        /// </summary>
        /// <param name="Entity">Contetns that has to be updated</param>
        /// <returns></returns>
        public string Update(Owner Entity)
        {
            log.Info("[OwnerService][Update]" );
            return _unitOfWork.ownerRepository.Update(Entity);
        }
        /// <summary>
        /// BAL Service Method to DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            log.Info("[OwnerService][Delete]" + id);
            throw new System.NotImplementedException();
        }
    }
}