﻿using Recruit.DataAccessLayer.Interface;
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
   public class CandidateRepository : IGenericRepository<Candidate>
    {
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CandidateRepository));


        IConnectionFactory _connectionFactory;
        public CandidateRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Method to perform Insert operation
        /// </summary>
        /// <param name="entity">Row values that has to be inserted</param>
        /// <returns></returns>
        string IGenericRepository<Candidate>.Add(Candidate entity)
        {
            int id;
            log.Info("[CandidateRepository][Add]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string insertQuery = @"INSERT INTO tbl_candidates([first_name],[last_name],[email],[phone],[source_code],[referral_id],
                                          [total_experience],[relevant_experience],[current_employer],[current_designation],[position_applied_code],
                                          [current_ctc],[expected_ctc],[reason_for_change],[notice_period],[is_serving_notice],[last_working_day],
                                          [current_location],[process_stage_id],[process_stage_date],[process_start_date],[process_end_date],[interview_status_id],
                                          [resume_owner_id],[owner_for_reminder_id],[comments],[date_of_joining],[notes],[links_for_interview])
                                           VALUES 
                                            (@first_name,@last_name,@email,@phone,@source_code,@referral_id,@total_experience,@relevant_experience,@current_employer,"
                                         + "@current_designation,@position_applied_code,@current_ctc,@expected_ctc,@reason_for_change,@notice_period," +
                                         "@is_serving_notice," +
                                         "@last_working_day,@current_location,@process_stage_id,@process_stage_date,@process_start_date,@process_end_date," +
                                         "@interview_status_id,@resume_owner_id,@owner_for_reminder_id,@comments,@date_of_joining,@notes,@links_for_interview );SELECT CAST(SCOPE_IDENTITY() as int)";

                    id = database.QuerySingle<int>(insertQuery, new{entity.first_name,entity.last_name,entity.email,entity.phone,entity.source_code,entity.referral_id,entity.total_experience,entity.relevant_experience,entity.current_employer,
                        entity.current_designation,entity.position_applied_code,entity.current_ctc,entity.expected_ctc, entity.reason_for_change,entity.notice_period,entity.is_serving_notice,entity.last_working_day,entity.current_location,entity.process_stage_id,  entity.process_stage_date,entity.process_start_date,entity.process_end_date,entity.interview_status_id,entity.resume_owner_id,entity.owner_for_reminder_id,entity.comments,entity.date_of_joining,entity.notes,entity.links_for_interview});


                }

                //foreach (int items in entity.location_id)
                //{
                    using (var database = _connectionFactory.GetConnection)
                    {
                        string insertQuery = @"INSERT INTO tbl_preferred_locations([candidate_id], [location_id])
                        VALUES (@id, @location_id)";

                        var result = database.Execute(insertQuery, new
                        {
                            id,
                            entity.location_id,


                        });

                    }
                
            
                log.Info("[CandidateRepository][Add]:Data save Successfully");
                //return 0;
               return ("Data save Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[CandidateRepository][Add]:" + exception);
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
        /// <param name="entity"></param>
        void IGenericRepository<Candidate>.Delete(Candidate entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to get required details
        /// </summary>
        /// <param name="entity"></param>

        public List<Candidate> GetRequired(int Id)
        {
            throw new NotImplementedException();
        }

        public Candidate Get(int id)
        {
            log.Info("[CandidateRepository][Get]");
            var data = new Candidate();
            try
            {

                data = GetAllRows().Where(records => records.id == id).FirstOrDefault();

                data.location_id = GetAllPreferredLocations(id);

            }
            catch (Exception exception)
            {
                log.Error("[CandidateRepository][Get]:" + exception);
            }
            return data;
        }
        /// <summary>
        /// Method to Perform Display fromm all the linked tables
        /// </summary>
        /// <returns></returns>
      public  List<Candidate> GetAll()
        {

         
            log.Info("[CandidateRepository][GetAll]");
            var data = new List<Candidate>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {

                    data = database.Query<Candidate>("SELECT  tbl_candidates.id, tbl_candidates.first_name, tbl_candidates.last_name, email, phone,tbl_sources.name as 'source_name', tbl_employees.name as 'emp_ref', total_experience, relevant_experience,current_employer, current_designation, tbl_vacancies.name as 'position', current_ctc, expected_ctc,reason_for_change, notice_period, is_serving_notice, last_working_day, current_location, tbl_preferred_locations.location_id, tbl_locations.city as 'Preferred_Location',tbl_process_stages.stage as 'stage',process_stage_date, process_start_date, process_end_date,tbl_process_statuses.status as 'status', t1.first_name as 'owner', t2.first_name as 'remind', comments,         date_of_joining, notes, links_for_interview FROM tbl_candidates LEFT JOIN tbl_employees ON tbl_candidates.referral_id = tbl_employees.id INNER JOIN  tbl_vacancies ON tbl_candidates.position_applied_code = tbl_vacancies.id INNER JOIN tbl_sources   ON  tbl_candidates.source_code = tbl_sources.id INNER JOIN tbl_process_statuses ON tbl_candidates.interview_status_id = tbl_process_statuses.id INNER JOIN tbl_process_stages ON tbl_candidates.process_stage_id = tbl_process_stages.id INNER JOIN tbl_owners as t1 ON tbl_candidates.resume_owner_id = t1.id INNER JOIN tbl_owners as t2 ON tbl_candidates.owner_for_reminder_id = t2.id LEFT JOIN tbl_preferred_locations ON tbl_candidates.id = tbl_preferred_locations.candidate_id LEFT JOIN tbl_locations ON tbl_preferred_locations.location_id = tbl_locations.id").ToList();
                }

            }
            catch (Exception exception)
            {
                log.Error("[CandidateRepository][GetAll]:" + exception);
            }
            return data;        
    }
        /// <summary>
        /// Method gets all the row values to perform search
        /// </summary>
        /// <returns></returns>
        public List<Candidate> GetAllRows()
        {

            log.Info("[CandidateRepository][GetAllRows]");
            var data = new List<Candidate>();
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {

                    data = database.Query<Candidate>("Select * from tbl_candidates").ToList();
                }
            }
            catch (Exception exception)
            {
                log.Error("[CandidateRepository][GetAllRows]:" + exception);
            }
            return data;


        }
        /// <summary>
        /// method to get preferred locations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public long GetAllPreferredLocations(int id)
        {
            log.Info("[InterviewDetailRepository][GetAllPreferredLocations]");

            long data = 0;
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string query = @"select location_id from tbl_preferred_locations WHERE candidate_id=@id";

                    data = database.QuerySingle<int>(query, new { id, });
                }
            }
            catch (Exception exception)
            {
                log.Error("[InterviewDetailRepository][GetAllPreferredLocations]:" + exception);
            }
            return data;


        }
        /// <summary>
        /// Method performs the UPDATE operation
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        string IGenericRepository<Candidate>.Update(Candidate entity)
        {
            log.Info("[CandidateRepository][Update]");
            try
            {
                using (var database = _connectionFactory.GetConnection)
                {
                    string updateQuery = @"UPDATE tbl_candidates SET first_name=@first_name,last_name=@last_name,email=@email,phone=@phone,
                                                                source_code=@source_code,referral_id=@referral_id,total_experience=@total_experience,relevant_experience=@relevant_experience,
                                            current_employer=@current_employer,current_designation=@current_designation,position_applied_code=@position_applied_code,
                                            current_ctc=@current_ctc,expected_ctc=@expected_ctc,reason_for_change=@reason_for_change,notice_period=@notice_period,
                                            is_serving_notice=@is_serving_notice,last_working_day=@last_working_day,current_location=@current_location,
                                            process_stage_id=@process_stage_id,process_stage_date=@process_stage_date,process_start_date=@process_start_date,
                                            process_end_date=@process_end_date,interview_status_id=@interview_status_id,resume_owner_id=@resume_owner_id,
                                             owner_for_reminder_id=@owner_for_reminder_id,comments=@comments,date_of_joining=@date_of_joining,notes=@notes,
                                            links_for_interview=@links_for_interview  WHERE id=@id";

                    var result = database.Execute(updateQuery, new
                    {
                        entity.id,
                        entity.first_name,      
                        entity.last_name,
                        entity.email,
                        entity.phone,
                        entity.source_code,
                        entity.referral_id,
                        entity.total_experience,
                        entity.relevant_experience,
                        entity.current_employer,
                        entity.current_designation,
                        entity.position_applied_code,
                        entity.current_ctc,
                        entity.expected_ctc,
                        entity.reason_for_change,
                        entity.notice_period,
                        entity.is_serving_notice,
                        entity.last_working_day,
                        entity.current_location,
                        entity.process_stage_id,
                        entity.process_stage_date,
                        entity.process_start_date,
                        entity.process_end_date,
                        entity.interview_status_id,
                        entity.resume_owner_id,
                        entity.owner_for_reminder_id,
                        entity.comments,
                        entity.date_of_joining,
                        entity.notes,
                        entity.links_for_interview
                    });
                }
                //foreach (int items in entity.location_id)
                //{
                    using (var database = _connectionFactory.GetConnection)
                    {
                        string updateQuery = @"UPDATE tbl_preferred_locations SET location_id=@location_id
                                            WHERE candidate_id=@id";


                        var result = database.Execute(updateQuery, new
                        {
                            entity.location_id,

                            entity.id

                        });

                    }
             //   }
                log.Info("[CandidateRepository][Update]:Data save Successfully");
                //return 2;
                return ("Data Updated Successfully");
            }
            catch (Exception exception)
            {
                log.Error("[CandidateRepository][Update]:" + exception);
                //if ((exception.Message).Contains("Violation of UNIQUE KEY constraint 'UK_tbl_locations_city'"))
                //{
                //    //return 3;
                //    return ("Update Unsuccessful " + exception.Message);
                //}
                return ("Update Unsuccessful " + exception.Message);
            }

        }
    }
    }

