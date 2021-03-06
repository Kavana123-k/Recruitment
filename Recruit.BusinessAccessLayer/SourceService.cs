﻿using Recruit.BusinessAccessLayer.Interface;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System.Collections.Generic;

namespace Recruit.BusinessAccessLayer
{
    public class SourceService : IService<Source>
    {
        readonly IUnitOfWork _unitOfWork;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SourceService));


        public SourceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// BAL service Method to Get Specific Rows
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Contents of the Row that is Specified</returns>
        public Source FindBy(int id)
        {
            log.Info("[SourceService][FindBy]" + id);
            return _unitOfWork.sourceRepository.Get(id);
        }
        /// <summary>
        /// BAL service Method to get all the Values from the table
        /// </summary>
        /// <returns>All the contents from the table</returns>
        public List<Source> FindbyAll()
        {
            log.Info("[SourceService][FindByAll]");
            return _unitOfWork.sourceRepository.GetAll();
        }
        /// <summary>
        /// BAL service Method to INSERT
        /// </summary>
        /// <param name="Entity">Value that needs to be inserted</param>
        /// <returns>Message</returns>
        public string Insert(Source Entity)
        {
            log.Info("[SourceService][Insert]");
            return _unitOfWork.sourceRepository.Add(Entity);
        }
        /// <summary>
        /// BAL service Method to UPDATE 
        /// </summary>
        /// <param name="Entity">Contetns that has to be updated</param>
        /// <returns></returns>
        public string Update(Source Entity)
        {
            log.Info("[SourceService][Update]" );
            return _unitOfWork.sourceRepository.Update(Entity);
        }
        /// <summary>
        /// BAL Service Method to DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            log.Info("[SourceService][Delete]");
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// BAL Service Method to Display required
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Source> GetRequired(int id)
        {
            log.Info("[GetRequired]");
            throw new System.NotImplementedException();
        }
    }
}