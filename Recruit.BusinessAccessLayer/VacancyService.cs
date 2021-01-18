using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class VacancyService : IService<Vacancy>
    {
        readonly IUnitOfWork _unitOfWork;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(VacancyService));
        public VacancyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// BAL service Method to Get Specific Rows
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Contents of the Row that is Specified</returns>
        public Vacancy FindBy(int id)
        {
            log.Info("[VacancyService][FindBy]");
            return _unitOfWork.vacancyRepository.Get(id);
        }
        /// <summary>
        /// BAL service Method to get all the Values from the table
        /// </summary>
        /// <returns>All the contents from the table</returns>
        public List<Vacancy> FindbyAll()
        {
            log.Info("[VacancyService][FindByAll]");
            return _unitOfWork.vacancyRepository.GetAll();
        }
        /// <summary>
        /// BAL service Method to INSERT
        /// </summary>
        /// <param name="Entity">Value that needs to be inserted</param>
        /// <returns>Message</returns>
        public string Insert(Vacancy Entity)
        {
            log.Info("[VacancyService][Insert]");
            return _unitOfWork.vacancyRepository.Add(Entity);
        }
        /// <summary>
        /// BAL service Method to UPDATE 
        /// </summary>
        /// <param name="Entity">Contetns that has to be updated</param>
        /// <returns></returns>
        public string Update(Vacancy Entity)
        {
            log.Info("[VacancyService][Update]");
            return _unitOfWork.vacancyRepository.Update(Entity);
        }
        /// <summary>
        /// BAL Service Method to DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            log.Info("[VacancyService][Delete]");
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// BAL Service Method to Display required
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Vacancy> GetRequired(int id)
        {
            log.Info("[GetRequired]");
            throw new System.NotImplementedException();
        }
    }
}