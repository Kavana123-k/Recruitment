using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class CandidateService :IService<Candidate>
    {
        readonly IUnitOfWork _unitOfWork;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CandidateService));

        // private IGenericRepository<Candidate> _GenericRepositoy;
        public CandidateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// BAL service Method to Get Specific Rows
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Contents of the Row that is Specified</returns>
        public Candidate FindBy(int id)
        {
            log.Info("[CandidateService][FindBy]" + id);
            return _unitOfWork.candidateRepository.Get(id);
        }
        /// <summary>
        /// BAL service Method to get all the Values from the table
        /// </summary>
        /// <returns>All the contents from the table</returns>
        public List<Candidate> FindbyAll()
        {
            log.Info("[CandidateService][FindbyAll]");
            return _unitOfWork.candidateRepository.GetAll();
        }
        /// <summary>
        /// BAL service Method to INSERT
        /// </summary>
        /// <param name="Entity">Value that needs to be inserted</param>
        /// <returns>Message</returns>
        public string Insert(Candidate Entity)
        {
            log.Info("[CandidateService][Insert]");
            return _unitOfWork.candidateRepository.Add(Entity);
        }
        /// <summary>
        /// BAL service Method to UPDATE 
        /// </summary>
        /// <param name="Entity">Contetns that has to be updated</param>
        /// <returns></returns>
        public string Update(Candidate Entity)
        {
            log.Info("[CandidateService][Update]");
            return _unitOfWork.candidateRepository.Update(Entity);
        }
        /// <summary>
        /// BAL Service Method to DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            log.Info("[CandidateService][Delete]");
            throw new System.NotImplementedException();
        }
    }
}