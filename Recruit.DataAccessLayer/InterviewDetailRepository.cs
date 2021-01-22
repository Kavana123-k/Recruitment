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
    public class InterviewDetailRepository : IGenericRepository<InterviewDetail>
    {


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(InterviewDetailRepository));
        IConnectionFactory _connectionFactory;
        public InterviewDetailRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Method to perform INSERT operation 
        /// </summary>
        /// <param name="entity">the row value which has to be inserted</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        public string Add(InterviewDetail entity)
        {
            int id;
            log.Info("[InterviewDetailRepository][Add]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string insertQuery = @"INSERT INTO tbl_interview_details([candidate_id], [start_date_time], [end_date_time],[status_id], [reason],[interview_stage_id])
                        VALUES (@candidate_id, @start_date_time, @end_date_time,@status_id, @reason,@interview_stage_id);
                        SELECT CAST(SCOPE_IDENTITY() as int)";


                     id = database.QuerySingle<int>(insertQuery, new { entity.candidate_id, entity.start_date_time, entity.end_date_time, entity.status_id, entity.reason,entity.interview_stage_id });


                }
             
               // foreach (int items in entity.employee_id) {
                    using (var database = _connectionFactory.GetConnection)
                    {
                        string insertQuery = @"INSERT INTO tbl_interviewers([candidate_id], [employee_id], [interview_id])
                        VALUES (@candidate_id, @employee_id, @id)";

                        var result = database.Execute(insertQuery, new
                        {
                            entity.candidate_id,
                            entity.employee_id,
                            id,

                        });
                    }

             //   }

                log.Info("[InterviewDetailRepository][Add]:Data save Successfully");
                //return 0;
                return ("Data save Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[InterviewDetailRepository][Add]:" + exception);
                //if ((exception.Message).Contains("Violation of UNIQUE KEY constraint 'UK_tbl_locations_city'"))
                //{
                //    //return 1;
                //    return ("Insert Unsuccessful " + exception.Message);
                //}
                return ("Insert Unsuccessful " + exception.Message);
            }

        }
        /// <summary>
        /// Method to perform DELETE operation
        /// </summary>
        /// <param name="entity">value that has to be deleted</param>
        void IGenericRepository<InterviewDetail>.Delete(InterviewDetail entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to DISPLAY A SPECIFIC record from the specified table from the DB
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>The Row values for the specified Primary Key</returns>
        public InterviewDetail Get(int id)
        {
            log.Info("[InterviewDetailRepository][Get]");
            var data = new InterviewDetail();
            try
            {
                data = GetAllRows().Where(records => records.id == id).FirstOrDefault();
               data.employee_id= GetAllInterviewers(id);
                
            }
            catch (Exception exception)
            {
                log.Error("[InterviewDetailRepository][Get]" + exception);
            }
            return data;
        }
        /// <summary>
        /// method to get interviewers details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public long GetAllInterviewers(int id)
        {
            log.Info("[InterviewDetailRepository][GetAllInterviewers]");

            long data=0;
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string query = @"select employee_id from tbl_interviewers WHERE interview_id=@id";

                    data = database.QuerySingle<Int64>(query, new { id, });
                }
            }
            catch (Exception exception)
            {
                log.Error("[InterviewDetailRepository][GetAllInterviewers]:" + exception);
            }
            return data;


        }
        /// <summary>
        /// Method to perform DISPLAY Operation
        /// </summary>
        /// <returns>ALL the contents in the table from the DB</returns>
        public List<InterviewDetail> GetAll()
        {

            log.Info("[GetAll]: ");
            var data = new List<InterviewDetail>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    data = database.Query<InterviewDetail>("SELECT tbl_interview_details.id,interview_stage_id,first_name," +
                        "start_date_time,end_date_time,status,reason FROM tbl_interview_details," +
                        "tbl_candidates,tbl_interview_round_statuses where" +
                        " tbl_interview_details.candidate_id = tbl_candidates.id and tbl_interview_details.status_id = tbl_interview_round_statuses.id").ToList();
                }
            }
            catch (Exception exception)
            {
                log.Error("[InterviewDetailRepository][GetAll]:" + exception);
            }
            return data;


        }
        /// <summary>
        /// Methods gets all the rows from the specified table to perform search operation
        /// </summary>
        /// <returns></returns>
        public List<InterviewDetail> GetAllRows()
        {
            log.Info("[InterviewDetailRepository][GetAllRows]");

            var data = new List<InterviewDetail>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    data = database.Query<InterviewDetail>("Select tbl_interview_details.id,interview_stage_id,candidate_id,tbl_candidates.first_name,start_date_time,end_date_time, status_id, reason from tbl_interview_details,tbl_candidates where  tbl_interview_details.candidate_id = tbl_candidates.id").ToList();
                }
            }
            catch (Exception exception)
            {
                log.Error("[InterviewDetailRepository][GetAllRows]:" + exception);
            }
            return data;


        }
        /// <summary>
        /// Method to Perform UPDATE operation
        /// </summary>
        /// <param name="entity">the row value which has to be Updated</param>
        /// <returns>String containing the message if successful and exception Message if not</returns>
        string IGenericRepository<InterviewDetail>.Update(InterviewDetail entity)
        {
            log.Info("[InterviewDetailRepository][Update]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string updateQuery = @"UPDATE tbl_interview_details SET candidate_id=@candidate_id,interview_stage_id=@interview_stage_id,start_date_time=@start_date_time,
                                            end_date_time=@end_date_time,status_id=@status_id,reason=@reason WHERE id=@id";

                    var result = database.Execute(updateQuery, new
                    {
                        entity.id,
                        entity.candidate_id,
                        entity.start_date_time,
                        entity.end_date_time,
                        entity.status_id,
                        entity.reason,
                        entity.interview_stage_id
                    });
                }
              //  foreach (int items in entity.employee_id)                {
                    using (var database = _connectionFactory.GetConnection)
                    {
                        string updateQuery = @"UPDATE tbl_interviewers SET candidate_id=@candidate_id,employee_id=@employee_id
                                            WHERE interview_id=@id";


                        var result = database.Execute(updateQuery, new
                        {
                            entity.candidate_id,
                            entity.employee_id,
                            entity.id,

                        });

                    }
             //   }
                log.Info("[InterviewDetailRepository][Update]:Data save Successfully");
                //return 2;
                return ("Data Updated Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[InterviewDetailRepository][Update]:" + exception);
                //if ((exception.Message).Contains("Violation of UNIQUE KEY constraint 'UK_tbl_locations_city'"))
                //{
                //    //return 3;
                //    return ("Insert Unsuccessful " + exception.Message);
                //}
                return ("Update Unsuccessful " + exception.Message);
            }

        }
        /// <summary>
        /// Method to get required details
        /// </summary>
        /// <param name="entity"></param>

        public List<InterviewDetail> GetRequired(int Id)
        {
            throw new NotImplementedException();
        }
    }
}


