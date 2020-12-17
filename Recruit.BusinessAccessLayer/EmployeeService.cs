using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class EmployeeService : IService<Employee>
    {
        readonly IUnitOfWork _unitOfWork;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeService));

        // private IGenericRepository<Candidate> _GenericRepositoy;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// BAL service Method to Get Specific Rows
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Contents of the Row that is Specified</returns>
        public Employee FindBy(int id)
        {
            log.Info("[EmployeeService][FindBy]" + id);
            return _unitOfWork.employeeRepository.Get(id);
        }
        /// <summary>
        /// BAL service Method to get all the Values from the table
        /// </summary>
        /// <returns>All the contents from the table</returns>
        public List<Employee> FindbyAll()
        {
            log.Info("[EmployeeService][FindByAll]");
            return _unitOfWork.employeeRepository.GetAll();
        }
        /// <summary>
        /// BAL service Method to INSERT
        /// </summary>
        /// <param name="Entity">Value that needs to be inserted</param>
        /// <returns>Message</returns>
        public string Insert(Employee Entity)
        {
            log.Info("[EmployeeService][Insert]");
            return _unitOfWork.employeeRepository.Add(Entity);
        }
        /// <summary>
        /// BAL service Method to UPDATE 
        /// </summary>
        /// <param name="Entity">Contetns that has to be updated</param>
        /// <returns></returns>
        public string Update(Employee Entity)
        {
            log.Info("[EmployeeService][Update]");
            return _unitOfWork.employeeRepository.Update(Entity);
        }
        /// <summary>
        /// BAL Service Method to DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            log.Info("[EmployeeService][Update]");
            throw new System.NotImplementedException();
        }
    }
}