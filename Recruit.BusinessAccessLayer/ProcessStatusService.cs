using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class ProcessStatusService : IService<ProcessStatus>
    {
        readonly IUnitOfWork _unitOfWork;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ProcessStatusService));

        
        public ProcessStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// BAL service Method to Get Specific Rows
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Contents of the Row that is Specified</returns>
        public ProcessStatus FindBy(int id)
        {
            log.Info("[ProcessStatusService][FindBy]" + id);
            return _unitOfWork.processStatusRepository.Get(id);
        }
        /// <summary>
        /// BAL service Method to get all the Values from the table
        /// </summary>
        /// <returns>All the contents from the table</returns>
        public List<ProcessStatus> FindbyAll()
        {
            log.Info("[ProcessStatusService][FindByAll]");
            return _unitOfWork.processStatusRepository.GetAll();
        }
        /// <summary>
        /// BAL service Method to INSERT
        /// </summary>
        /// <param name="Entity">Value that needs to be inserted</param>
        /// <returns>Message</returns>
        public string Insert(ProcessStatus Entity)
        {
            log.Info("[ProcessStatusService][Insert]");
            return _unitOfWork.processStatusRepository.Add(Entity);
        }
        /// <summary>
        /// BAL service Method to UPDATE 
        /// </summary>
        /// <param name="Entity">Contetns that has to be updated</param>
        /// <returns></returns>
        public string Update(ProcessStatus Entity)
        {
            log.Info("[ProcessStatusService][Update]");
            return _unitOfWork.processStatusRepository.Update(Entity);
        }
        /// <summary>
        /// BAL Service Method to DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            log.Info("[ProcessStatusService][Delete]" + id);
            throw new System.NotImplementedException();
        }
    }
}