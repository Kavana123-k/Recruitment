//using Recruit.BusinessAccessLayer.Interface;
//using Recruit.DataAccessLayer.Interface;
//using Recruit.Models;
//using System.Collections.Generic;

//namespace Recruit.BusinessAccessLayer
//{
//    public class InterviewerService : IService<Employee>
//    {
//        readonly IUnitOfWork _unitOfWork;
//        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(InterviewerService));

//        // private IGenericRepository<Candidate> _GenericRepositoy;
//        public InterviewerService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        /// <summary>
//        /// BAL service Method to Get Specific Rows
//        /// </summary>
//        /// <param name="id">Primary key</param>
//        /// <returns>Contents of the Row that is Specified</returns>
//        public Interviewer FindBy(int id)
//        {
//            log.Info("[InterviewerService][FindBy]" + id);
//            return _unitOfWork.interviewerRepository.Get(id);
//        }
//        /// <summary>
//        /// BAL service Method to get all the Values from the table
//        /// </summary>
//        /// <returns>All the contents from the table</returns>
//        public List<Interviewer> FindbyAll()
//        {
//            log.Info("[InterviewerService][FindByAll]");
//            return _unitOfWork.interviewerRepository.GetAll();
//        }
//        /// <summary>
//        /// BAL service Method to INSERT
//        /// </summary>
//        /// <param name="Entity">Value that needs to be inserted</param>
//        /// <returns>Message</returns>
//        public string Insert(Interviewer Entity)
//        {
//            log.Info("[InterviewerService][Insert]");
//            return _unitOfWork.interviewerRepository.Add(Entity);
//        }
//        /// <summary>
//        /// BAL service Method to UPDATE 
//        /// </summary>
//        /// <param name="Entity">Contetns that has to be updated</param>
//        /// <returns></returns>
//        public string Update(Interviewer Entity)
//        {
//            log.Info("[EmployeeService][Update]");
//            return _unitOfWork.interviewerRepository.Update(Entity);
//        }
//        /// <summary>
//        /// BAL Service Method to DELETE
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public bool Delete(int id)
//        {
//            log.Info("[InterviewerService][Update]");
//            throw new System.NotImplementedException();
//        }
//    }
//}