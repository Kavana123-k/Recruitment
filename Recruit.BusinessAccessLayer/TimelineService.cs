using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class TimelineService : IService<Timeline>
    {
        readonly IUnitOfWork _unitOfWork;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TimelineService));

        // private IGenericRepository<Candidate> _GenericRepositoy;
        public TimelineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// BAL service Method to Get Specific Rows
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Contents of the Row that is Specified</returns>
      public Timeline FindBy(int id)
        {
            log.Info("[InterviewerService][FindBy]" + id);
            throw new System.NotImplementedException();
        }
    /// <summary>
    /// BAL service Method to get all the Values from the table
    /// </summary>
    /// <returns>All the contents from the table</returns>
    public List<Timeline> FindbyAll()
    {
        log.Info("[InterviewerService][FindByAll]");
            throw new System.NotImplementedException();
        }
    /// <summary>
    /// BAL service Method to INSERT
    /// </summary>
    /// <param name="Entity">Value that needs to be inserted</param>
    /// <returns>Message</returns>
    public string Insert(Timeline Entity)
    {
        log.Info("[InterviewerService][Insert]");
            throw new System.NotImplementedException();
        }
    /// <summary>
    /// BAL service Method to UPDATE 
    /// </summary>
    /// <param name="Entity">Contetns that has to be updated</param>
    /// <returns></returns>
    public string Update(Timeline Entity)
    {
        log.Info("[EmployeeService][Update]");
            throw new System.NotImplementedException();
        }
    /// <summary>
    /// BAL Service Method to DELETE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        log.Info("[Update]");
        throw new System.NotImplementedException();
    }

    public List<Timeline> GetRequired(int id)
        {
            log.Info("[GetRequired]");
            return _unitOfWork.timelineRepository.GetRequired(id);
        }
    }
}