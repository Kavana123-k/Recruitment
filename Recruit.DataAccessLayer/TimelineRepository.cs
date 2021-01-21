using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;
using log4net;

namespace Recruit.DataAccessLayer
{
    public class TimelineRepository : IGenericRepository<Timeline>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TimelineRepository));


        IConnectionFactory _connectionFactory;
        public TimelineRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Method to perform INSERT operation 
        /// </summary>
        /// <param name="entity">the row value which has to be inserted</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        public string Add(Timeline entity)
        {
            log.Info("[SourceRepository][Add]");
            throw new NotImplementedException();

        }
        /// <summary>
        /// Method to perform DELETE operation
        /// </summary>
        /// <param name="entity">value that has to be deleted</param>
       public void Delete(Timeline entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to DISPLAY A SPECIFIC record from the specified table from the DB
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>The Row values for the specified Primary Key</returns>
        public Timeline Get(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to perform DISPLAY Operation
        /// </summary>
        /// <returns>ALL the contents in the table from the DB</returns>
        public List<Timeline> GetAll()
        {

            log.Info("[GetAll]");
            var data = new List<Timeline>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    data = database.Query<Timeline>("SELECT tbl_interview_details.id, tbl_process_stages.stage as 'stage', tbl_interview_details.candidate_id,first_name,start_date_time, end_date_time, status_id, status, reason,STRING_AGG(tbl_employees.name, ', ') within group(order by tbl_employees.id desc) as emp_name FROM tbl_interview_details INNER JOIN tbl_candidates ON  tbl_interview_details.candidate_id = tbl_candidates.id INNER JOIN tbl_interview_round_statuses ON  tbl_interview_details.status_id = tbl_interview_round_statuses.id LEFT JOIN tbl_interviewers ON   tbl_interview_details.id = tbl_interviewers.interview_id LEFT JOin tbl_employees ON tbl_interviewers.employee_id =tbl_employees.id LEFT JOin tbl_process_stages ON tbl_interview_details.interview_stage_id = tbl_process_stages.id group by  tbl_interview_details.id, tbl_process_stages.stage, tbl_interview_details.candidate_id,first_name, start_date_time, end_date_time, status_id,status,reason order by(start_date_time)").ToList();
                }
            }
            catch (Exception exception)
            {
                log.Error("[SourceRepository][GetAll]" + exception);
            }
            return data;

           


        }
        /// <summary>
        /// Method to Perform UPDATE operation
        /// </summary>
        /// <param name="entity">the row value which has to be Updated</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        public string Update(Timeline entity)
        {
            log.Info("[SourceRepository][Update]");
            throw new NotImplementedException();

        }
        /// <summary>
        /// Method to get required details
        /// </summary>
        /// <param name="entity"></param>

        public List<Timeline> GetRequired(int id)
        {
            log.Info("[GetRequired]");

            var data = new List<Timeline>();
            
            try
            {
                data = GetAll().Where(records => records.candidate_id == id).ToList(); 
               
            }
            catch (Exception exception)
            {
                log.Error("[SourceRepository][Get]" + exception);
            }
    
            return data;

        }
    }
}

