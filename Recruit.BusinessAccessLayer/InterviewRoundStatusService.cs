using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class InterviewRoundStatusService : IService<InterviewRoundStatus>
    {
        readonly IUnitOfWork _unitOfWork;


        // private IGenericRepository<Candidate> _GenericRepositoy;
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
            return _unitOfWork.interviewRoundStatusRepository.Get(id);
        }
        /// <summary>
        /// BAL service Method to get all the Values from the table
        /// </summary>
        /// <returns>All the contents from the table</returns>
        public List<InterviewRoundStatus> FindbyAll()
        {

            return _unitOfWork.interviewRoundStatusRepository.GetAll();
        }
        /// <summary>
        /// BAL service Method to INSERT
        /// </summary>
        /// <param name="Entity">Value that needs to be inserted</param>
        /// <returns>Message</returns>
        public string Insert(InterviewRoundStatus Entity)
        {
            return _unitOfWork.interviewRoundStatusRepository.Add(Entity);
        }
        /// <summary>
        /// BAL service Method to UPDATE 
        /// </summary>
        /// <param name="Entity">Contetns that has to be updated</param>
        /// <returns></returns>
        public string Update(InterviewRoundStatus Entity)
        {
            return _unitOfWork.interviewRoundStatusRepository.Update(Entity);
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
    }
}