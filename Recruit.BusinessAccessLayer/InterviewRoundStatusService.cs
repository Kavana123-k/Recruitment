using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class InterviewRoundStatusService : IService<InterviewRoundStatus>
    {
        readonly IUnitOfWork _unitOfWork;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(InterviewRoundStatusService));

        
        public InterviewRoundStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// BAL service Method to Get Specific Rows
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Contents of the Row that is Specified</returns>
        public InterviewRoundStatus FindBy(int id)
        {
            log.Info("[InterviewRoundStatusService][FindBy]" + id);
            return _unitOfWork.interviewRoundStatusRepository.Get(id);
        }
        /// <summary>
        /// BAL service Method to get all the Values from the table
        /// </summary>
        /// <returns>All the contents from the table</returns>
        public List<InterviewRoundStatus> FindbyAll()
        {
            log.Info("[InterviewRoundStatusService][FindByAll]");
            return _unitOfWork.interviewRoundStatusRepository.GetAll();
        }
        /// <summary>
        /// BAL service Method to INSERT
        /// </summary>
        /// <param name="Entity">Value that needs to be inserted</param>
        /// <returns>Message</returns>
        public string Insert(InterviewRoundStatus Entity)
        {
            log.Info("[InterviewRoundStatusService][Insert]");
            return _unitOfWork.interviewRoundStatusRepository.Add(Entity);
        }
        /// <summary>
        /// BAL service Method to UPDATE 
        /// </summary>
        /// <param name="Entity">Contetns that has to be updated</param>
        /// <returns></returns>
        public string Update(InterviewRoundStatus Entity)
        {
            log.Info("[InterviewRoundStatusService][Update]");
            return _unitOfWork.interviewRoundStatusRepository.Update(Entity);
        }
        /// <summary>
        /// BAL Service Method to DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            log.Info("[InterviewRoundStatusService][Delete]" + id);
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// BAL Service Method to Display required
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<InterviewRoundStatus> GetRequired(int id)
        {
            log.Info("[GetRequired]");
            throw new System.NotImplementedException();
        }
    }
}