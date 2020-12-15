using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class InterviewDetailService : IService<InterviewDetail>
    {
        readonly IUnitOfWork _unitOfWork;


        // private IGenericRepository<Candidate> _GenericRepositoy;
        public InterviewDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// BAL service Method to Get Specific Rows
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Contents of the Row that is Specified</returns>
        public InterviewDetail FindBy(int id)
        {
            return _unitOfWork.interviewDetailRepository.Get(id);
        }
        /// <summary>
        /// BAL service Method to get all the Values from the table
        /// </summary>
        /// <returns>All the contents from the table</returns>
        public List<InterviewDetail> FindbyAll()
        {

            return _unitOfWork.interviewDetailRepository.GetAll();
        }
        /// <summary>
        /// BAL service Method to INSERT
        /// </summary>
        /// <param name="Entity">Value that needs to be inserted</param>
        /// <returns>Message</returns>
        public string Insert(InterviewDetail Entity)
        {
            return _unitOfWork.interviewDetailRepository.Add(Entity);
        }
        /// <summary>
        /// BAL service Method to UPDATE 
        /// </summary>
        /// <param name="Entity">Contetns that has to be updated</param>
        /// <returns></returns>
        public string Update(InterviewDetail Entity)
        {
            return _unitOfWork.interviewDetailRepository.Update(Entity);
        }
    
        ///  <summary>
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