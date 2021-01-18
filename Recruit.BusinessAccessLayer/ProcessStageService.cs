using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class ProcessStageService : IService<ProcessStage>
    {
        readonly IUnitOfWork _unitOfWork;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ProcessStageService));
        
        public ProcessStageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// BAL service Method to Get Specific Rows
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Contents of the Row that is Specified</returns>
        public ProcessStage FindBy(int id)
        {
            log.Info("[ProcessStageService][FindBy]" + id);
            return _unitOfWork.processStageRepository.Get(id);
        }
        /// <summary>
        /// BAL service Method to get all the Values from the table
        /// </summary>
        /// <returns>All the contents from the table</returns>
        public List<ProcessStage> FindbyAll()
        {
            log.Info("[ProcessStageService][FindByAll]");
            return _unitOfWork.processStageRepository.GetAll();
        }
        /// <summary>
        /// BAL service Method to INSERT
        /// </summary>
        /// <param name="Entity">Value that needs to be inserted</param>
        /// <returns>Message</returns>
        public string Insert(ProcessStage Entity)
        {
            log.Info("[ProcessStageService][Insert]");
            return _unitOfWork.processStageRepository.Add(Entity);
        }
        /// <summary>
        /// BAL service Method to UPDATE 
        /// </summary>
        /// <param name="Entity">Contetns that has to be updated</param>
        /// <returns></returns>
        public string Update(ProcessStage Entity)
        {
            log.Info("[ProcessStageService][Update]");
            return _unitOfWork.processStageRepository.Update(Entity);
        }
        /// <summary>
        /// BAL Service Method to DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            log.Info("[ProcessStageService][Delete]" + id);
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// BAL Service Method to Display required
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ProcessStage> GetRequired(int id)
        {
            log.Info("[GetRequired]");
            throw new System.NotImplementedException();
        }
    }
}